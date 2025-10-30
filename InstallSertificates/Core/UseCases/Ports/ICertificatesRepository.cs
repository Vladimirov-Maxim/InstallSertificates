using InstallСertificates.Core.Domain;

namespace InstallСertificates.Core.UseCases.Ports
{
    public interface ICertificatesRepository
    {
        public void Save(CertificatesAggregate installCertificates);
        public CertificatesAggregate Get();
    }
}
