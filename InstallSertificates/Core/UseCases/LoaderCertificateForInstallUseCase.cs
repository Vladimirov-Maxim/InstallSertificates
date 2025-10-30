using InstallSertificates.Core.UseCases.Ports;

namespace InstallSertificates.Core.UseCases
{
    public class LoaderCertificateForInstallUseCase : ILoaderCertificatesForInstallInput
    {
        private readonly IMainViewOutput _mainViewOutput;
        private readonly ILoaderCertificateForInstallRepositories _loaderCertificateForInstall;
        private readonly ICertificatesGateway _certificatesGateway;
        private readonly ICertificatesRepository _certificatesRepository;

        public LoaderCertificateForInstallUseCase(IMainViewOutput mainViewOutput, ILoaderCertificateForInstallRepositories loaderCertificateForInstall, ICertificatesGateway certificatesGateway, ICertificatesRepository certificatesRepository)
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

            if (certificates.Count == 0)
                return;

            var cerRun = _certificatesRepository.Get();
            cerRun.LoadCertificatesFofInstall(certificates);

            var installedCer = cerRun.GetInstalledCertificates();
            foreach (var cer in certificates)
            {
                if (installedCer.Where(s => s.SerialNumber == cer.SerialNumber).Count() > 0)
                {
                    cerRun.Install(cer.SerialNumber, cer.ContainerAddress, "");
                    cer.Installed = true;
                }
            }

            _certificatesRepository.Save(cerRun);
            _mainViewOutput.ShowCertificatesForInstall(certificates);

        }
    }
}
