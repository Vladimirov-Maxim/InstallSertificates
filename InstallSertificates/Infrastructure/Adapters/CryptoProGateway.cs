using InstallSertificates.Core.UseCases.Ports;
using System.Diagnostics;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace InstallSertificates.Infrastructure.Adapters
{
    public class CryptoProGateway : ICertificatesGateway
    {

        private string exePath = @"C:\Program Files\Crypto Pro\CSP\certmgr.exe";

        public CryptoProGateway()
        {
            if (!Path.Exists(exePath))
                throw new FileNotFoundException($"Не найден исполняемый файл КриптоПро {exePath}.");
        }

        public CertificateInfo CertificateFromFile(string file)
        {
            var cer = new X509Certificate2(file);
            return new CertificateInfo(
                cer.Subject,
                cer.Issuer,
                Path.GetFileNameWithoutExtension(file),
                cer.NotAfter,
                cer.NotBefore,
                cer.SerialNumber,
                false
                );
        }

        public List<CertificateInfo> GetCertificates()
        {
            var cer_inf = CertificatesInfo();
            return ParseToCertificatesInfo(cer_inf);
        }

        public string Install(string folderCertificates, string nameCer)
        {

            string fullNameCertificate = Path.Combine(folderCertificates, nameCer);
            fullNameCertificate = Path.ChangeExtension(fullNameCertificate, "cer");

            var containers = AvailableContainers();

            foreach (var container in containers)
            {
                if (InstallToContainer(fullNameCertificate, container))
                    return container;
            }

            return string.Empty;

        }

        private string CertificatesInfo()
        {

            var psi = new ProcessStartInfo(exePath)
            {
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };
            psi.ArgumentList.Add("-list");
            psi.ArgumentList.Add("-store");
            psi.ArgumentList.Add("uMy");

            var resultProcess = LocalProcess.StartProcess(psi);

            if (resultProcess.code != 0)
                throw new InvalidOperationException($"Ошибка при получения сертификатов CryptoPro {resultProcess.code}: {resultProcess.err_text}");

            return resultProcess.out_text;

        }

        private List<CertificateInfo> ParseToCertificatesInfo(string cer_inf)
        {

            var certificates = new List<CertificateInfo>();

            var certificates_inf = cer_inf.Split("-------");

            foreach (var cer in certificates_inf)
            {

                var serialNumber = GetProperty(cer, "Серийный номер", "SerialNumber");
                if (string.IsNullOrEmpty(serialNumber))
                    continue;

                var issuer = GetProperty(cer, "Издатель", "Issuer");
                var subject = GetProperty(cer, "Субъект", "Subject");
                var issued = GetProperty(cer, "Выдан", "Issued");
                var expires = GetProperty(cer, "Истекает", "Expires");
                var container = GetProperty(cer, "Контейнер", "Container");

                var certificate = new CertificateInfo(
                    subject,
                    subject,
                    TryParseDate(issued),
                    TryParseDate(expires),
                    serialNumber.Substring(2),
                    issuer,
                    container,
                    true,
                    "");
                  
                    certificates.Add(certificate);

                }

            return certificates;
        }

        private string GetProperty(string text, string nameRu, string nameEn)
        {
            var valueMatch = Regex.Match(text, $"{nameRu}\\s*:\\s(?<{nameEn}>.*)?", RegexOptions.Compiled);
            return valueMatch.Success ? valueMatch.Groups[1].Value.Trim() : string.Empty;

        }

        private DateTime TryParseDate(string date) {

            try
            {
                var dto = DateTimeOffset.ParseExact(
                    date,
                    "dd/MM/yyyy HH:mm:ss 'UTC'",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal);

                return dto.DateTime;

            } catch {

                return DateTime.MinValue;

            }

        }

        private List<string> AvailableContainers()
        
        {
            var result = new List<string>();

            var csptest = @"C:\Program Files\Crypto Pro\CSP\csptest.exe";
            if (!File.Exists(csptest))
                throw new FileNotFoundException($"Не найден исполняемый файл КриптоПро {csptest}.");

            var psi = new ProcessStartInfo(csptest)
            {
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };
            psi.ArgumentList.Add("-keyset");
            psi.ArgumentList.Add("-enum_cont");
            psi.ArgumentList.Add("-fqcn");
            psi.ArgumentList.Add("-verifyc");

            var resultProcess = LocalProcess.StartProcess(psi);

            if (resultProcess.code != 0)
                throw new InvalidOperationException($"Ошибка при получение списка контейнеров {resultProcess.code}: {resultProcess.err_text}");

            var containersMatch = Regex.Matches(resultProcess.out_text, @"\\\\.\\Aktiv Rutoken ECP 0\\ID_.*");
            foreach (Match match in containersMatch)
                result.Add(match.Value);

            return result;

        }

        private bool InstallToContainer(string fullNameCertificate, string container)
        {
            var psi = new ProcessStartInfo(exePath)
            {
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };
            psi.ArgumentList.Add("-install");
            psi.ArgumentList.Add("-store");
            psi.ArgumentList.Add("uMy");
            psi.ArgumentList.Add("-file");
            psi.ArgumentList.Add(fullNameCertificate);
            psi.ArgumentList.Add("-container");
            psi.ArgumentList.Add(container.Trim());
            psi.ArgumentList.Add("-silent");

            var result = LocalProcess.StartProcess(psi);
            return result.code == 0;
            
        }

    }
}
