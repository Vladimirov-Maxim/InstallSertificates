using System.Security.Cryptography.X509Certificates;
using InstallSertificates.Core.UseCases.Ports;

namespace InstallSertificates.Infrastructure.Adapters
{
    internal class X509StoreGateway : ICertificatesGateway
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

        public List<CertificateInfo> GetCertificates()
        {

            var store = new X509Store(StoreName.Root, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);

            var sertificates = store.
                Certificates.
                Cast<X509Certificate2>().
                Select(s => new CertificateInfo(
                    s.Subject,
                    s.Issuer,
                    s.FriendlyName,
                    s.NotAfter,
                    s.NotBefore,
                    s.SerialNumber,
                    true)
             ).ToList();

            store.Close();

            return sertificates;

        }
    }
}
