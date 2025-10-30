using InstallSertificates.Core.UseCases.Ports;

namespace InstallSertificates.Core.Domain
{
    public class CertificatesAggregate
    {
        private List<Certificate> _certificatesForInstall { get; set; } = new List<Certificate>();
        private List<Certificate> _installedCertificates { get; set; } = new List<Certificate>();

        public void LoadInstalledCertificates(List<CertificateInfo> certificates)
        {

            _installedCertificates.Clear();

            foreach (var cer in certificates)
                _installedCertificates.Add(CertificateFromCerInfo(cer));
           
        }

        public void LoadCertificatesFofInstall(List<CertificateInfo> certificates)
        {

            _certificatesForInstall.Clear();

            foreach (var cer in certificates)
                _certificatesForInstall.Add(CertificateFromCerInfo(cer));

        }

        public List<CertificateInfo> GetInstalledCertificates()
        {
            List<CertificateInfo> certificates = new List<CertificateInfo>();

            foreach (var certificate in _installedCertificates)
                certificates.Add(CerInfoFromCertificate(certificate));
           
            return certificates;

        }

        public List<CertificateInfo> GetCertificatesForInstall()
        {
            List<CertificateInfo> certificates = new List<CertificateInfo>();

            foreach (var certificate in _certificatesForInstall)
                certificates.Add(CerInfoFromCertificate(certificate));
            
            return certificates;
        }

        private CertificateInfo CerInfoFromCertificate(Certificate certificate)
        {
            return new CertificateInfo(
                certificate.Name,
                certificate.Subject,
                certificate.NotBefore,
                certificate.NotAfter,
                certificate.SerialNumber,
                certificate.Issuer,
                certificate.ContainerAddress,
                certificate.Installed,
                certificate.USBPort);
        }

        private Certificate CertificateFromCerInfo(CertificateInfo cer)
        {
            return new Certificate(
                cer.Name,
                cer.Subject,
                cer.Issuer,
                cer.NotBefore,
                cer.NotAfter,
                cer.SerialNumber,
                cer.Installed,
                "",
                cer.ContainerAddress);
        }

        public void Install(string SerialNumber, string container, string port)
        {
            var cer = _certificatesForInstall.
                FirstOrDefault(c => string.Equals(c.SerialNumber, SerialNumber, StringComparison.OrdinalIgnoreCase));

            if (cer == null)
                throw new ArgumentException($"Не удалось найти сертификат для установки с номером {SerialNumber}");

            cer.Install(container, port);
        }

    }
}
