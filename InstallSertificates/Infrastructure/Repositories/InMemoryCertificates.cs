using InstallSertificates.Core.Domain;
using InstallSertificates.Core.UseCases.Ports;

namespace InstallSertificates.Infrastructure.Repositories
{
    public class InMemoryCertificates : ICertificatesRepository
    {

        private CertificatesAggregate? _certificates;

        public CertificatesAggregate Get() => _certificates;

        public void Save(CertificatesAggregate installCertificates) => _certificates = installCertificates;


    }
}
