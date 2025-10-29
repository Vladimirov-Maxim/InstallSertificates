using InstallSertificates.Core.UseCases.Ports;
using InstallSertificates.InterfaceAdapters.Controllers.Ports;

namespace InstallSertificates.InterfaceAdapters.Controllers
{
    public class MainViewController : IMainViewController
    {
        private ILoaderCertificatesForInstallInput _loaderCertificatesForInstall;
        private IInstalledSertificatesUseCaseInput _loaderInstalledCertificates;

        public MainViewController(ILoaderCertificatesForInstallInput loaderCertificatesForInstall, IInstalledSertificatesUseCaseInput loaderInstalledCertificates)
        {
            _loaderCertificatesForInstall = loaderCertificatesForInstall;
            _loaderInstalledCertificates = loaderInstalledCertificates;
        }

        public void InstalledCertificates()
        {
            _loaderInstalledCertificates.InstalledCertificates();
        }

        public void InstalledCertificatesFilter(string query)
        {
            _loaderInstalledCertificates.InstalledCertificatesFilter(query);
        }

        public void LoadCertificatesForInstall(string PathFolder)
        {
            _loaderCertificatesForInstall.CertificatesForInstall(PathFolder);
        }
    }
}
