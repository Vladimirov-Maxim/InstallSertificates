using InstallSertificates.Core.UseCases.Ports;

namespace InstallSertificates.Core.Domain
{
    public class InstallCertificates
    {
        public List<Certificate> Certificates { get; set; } = new List<Certificate>();

        public InstallCertificates(List<CertificateInfo> certificates)
        {
            foreach (var cer in certificates)
            {
                var cerInfo = new Certificate(
                    cer.Subject,
                    cer.Issuer,
                    cer.Name,
                    cer.NotAfter,
                    cer.NotBefore,
                    cer.SerialNumber,
                    cer.Installed);

                Certificates.Add(cerInfo);
            }

        }

        public void Install(string SerialNumber)
        {
            var cer = Certificates.Where(c => c.SerialNumber == SerialNumber).First();

            if (cer == null)
            {
                throw new ArgumentException($"Не удалось найти сертификат для установки с номером {SerialNumber}");
            }

            cer.Install();
        }

    }
}
