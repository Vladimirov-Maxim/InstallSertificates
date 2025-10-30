using InstallСertificates.Core.Domain;
using InstallСertificates.Core.UseCases.Ports;

namespace InstallСertificates.Infrastructure.Repositories
{
    public class InMemoryCertificates : ICertificatesRepository
    {

        private CertificatesAggregate? _certificates;

        public CertificatesAggregate Get() => _certificates;

        public void Save(CertificatesAggregate installCertificates) => _certificates = installCertificates;


    }
}
