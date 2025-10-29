using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using InstallSertificates.Core.UseCases.Ports;

namespace InstallSertificates.Infrastructure.Adapters
{
    internal class CryptoProGateway : ICertificatesGateway
    {
        public CertificateInfo CertificateFromFile(string file)
        {
            var cer = new X509Certificate2(file);
            return new CertificateInfo(
                cer.Subject,
                cer.Issuer,
                Path.GetFileName(file),
                cer.NotAfter,
                cer.NotBefore,
                cer.SerialNumber,
                false
                );
        }

        public List<CertificateInfo> GetCertificates(string file)
        {
            
        }

        private string CertificatesInfo()
        {

            var psi = new ProcessStartInfo()
            {
                UseShellExecute = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };
            psi.ArgumentList.Add("-list");
            psi.ArgumentList.Add("-store");
            psi.ArgumentList.Add("uMy");

            try
            {
                psi.StandardOutputEncoding = Encoding.GetEncoding(CultureInfo.CurrentCulture.TextInfo.OEMCodePage);
            }
            catch {
                psi.StandardOutputEncoding = Encoding.UTF8;
            }
            psi.StandardErrorEncoding = psi.StandardOutputEncoding;

            var process = Process.Start(psi);

            if (process == null) {
                throw new InvalidOperationException("Не удалось запустить процесс получения сертификатов");
            }

            string out_text = process.StandardOutput.ReadToEnd();
            string err_text = process.StandardError.ReadToEnd();

            process.WaitForExit();

            if (process.ExitCode != 0 && string.IsNullOrWhiteSpace(out_text))
                throw new InvalidOperationException($"Ошибка при получения сертификатов CryptoPro {process.ExitCode}: {err_text}");

            return out_text;

        }

    }
}
