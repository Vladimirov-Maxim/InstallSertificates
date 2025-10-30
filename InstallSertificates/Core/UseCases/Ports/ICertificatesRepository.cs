using InstallSertificates.Core.Domain;

namespace InstallSertificates.Core.UseCases.Ports
{
    public interface ICertificatesRepository
    {
        public void Save(CertificatesAggregate installCertificates);
        public CertificatesAggregate Get();
    }
}
