using InstallSertificates.Core.Domain;
using InstallSertificates.Core.UseCases.Ports;

namespace InstallSertificates.Infrastructure.Repositories
{
    public class InMemoryCertificatesForInstall : IInstallCertificatesRepository
    {

        private InstallCertificates? _certificates;

        public InstallCertificates Get() => _certificates;

        public void Save(InstallCertificates installCertificates) => _certificates = installCertificates;


    }
}
