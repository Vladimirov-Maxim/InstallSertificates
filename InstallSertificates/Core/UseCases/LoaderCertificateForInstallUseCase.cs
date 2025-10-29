using InstallSertificates.Core.Domain;
using InstallSertificates.Core.UseCases.Ports;

namespace InstallSertificates.Core.UseCases
{
    public class LoaderCertificateForInstallUseCase : ILoaderCertificatesForInstallInput
    {
        private readonly IMainViewOutput _mainViewOutput;
        private readonly ILoaderCertificateForInstallRepositories _loaderCertificateForInstall;
        private readonly ICertificatesGateway _certificatesGateway;
        private readonly IInstallCertificatesRepository _certificatesRepository;

        public LoaderCertificateForInstallUseCase(IMainViewOutput mainViewOutput, ILoaderCertificateForInstallRepositories loaderCertificateForInstall, ICertificatesGateway certificatesGateway, IInstallCertificatesRepository certificatesRepository)
        {
            _mainViewOutput = mainViewOutput ?? throw new ArgumentNullException(nameof(mainViewOutput));
            _loaderCertificateForInstall = loaderCertificateForInstall ?? throw new ArgumentNullException(nameof(loaderCertificateForInstall));
            _certificatesGateway = certificatesGateway ?? throw new ArgumentNullException(nameof(certificatesGateway));
            _certificatesRepository = certificatesRepository ?? throw new ArgumentNullException(nameof(certificatesRepository));
        }

        public void CertificatesForInstall(string PathFolder)
        {

            List<CertificateInfo> certificates = new List<CertificateInfo>();

            var certificateFiles = _loaderCertificateForInstall.GetCertificatesForInstall(PathFolder);
            foreach (var file in certificateFiles)
                certificates.Add(_certificatesGateway.CertificateFromFile(file));

            var certificatesForInstall = new InstallCertificates(certificates);
            _certificatesRepository.Save(certificatesForInstall);

            _mainViewOutput.ShowCertificatesForInstall(certificates);

        }
    }
}
