using InstallСertificates.Core.UseCases.Ports;
using InstallСertificates.InterfaceAdapters.Controllers.Ports;

namespace InstallСertificates.InterfaceAdapters.Controllers
{
    public class MainViewController : IMainViewController
    {
        private ILoaderCertificatesForInstallInput _loaderCertificatesForInstall;
        private IInstalledSertificatesUseCaseInput _loaderInstalledCertificates;
        private IInstallCertificatesUseCaseInput _installCertificates;

        public MainViewController(
            ILoaderCertificatesForInstallInput loaderCertificatesForInstall,
            IInstalledSertificatesUseCaseInput loaderInstalledCertificates,
            IInstallCertificatesUseCaseInput installCertificates)
        {
            _loaderCertificatesForInstall = loaderCertificatesForInstall;
            _loaderInstalledCertificates = loaderInstalledCertificates;
            _installCertificates = installCertificates;
        }

        public void Install(string serialNumber, string nameCer, string folderCertificates)
        {
            _installCertificates.Install(serialNumber, nameCer, folderCertificates);
        }

        public void InstalledCertificates() => _loaderInstalledCertificates.InstalledCertificates();

        public void InstalledCertificatesFilter(string query) => _loaderInstalledCertificates.InstalledCertificatesFilter(query);
    
        public void LoadCertificatesForInstall(string pathFolder) => _loaderCertificatesForInstall.CertificatesForInstall(pathFolder);
    }
}
