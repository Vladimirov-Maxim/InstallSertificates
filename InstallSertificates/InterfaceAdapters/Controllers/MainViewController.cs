using InstallSertificates.Core.UseCases.Ports;
using InstallSertificates.InterfaceAdapters.Controllers.Ports;

namespace InstallSertificates.InterfaceAdapters.Controllers
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

        public void Install(string SerialNumber, string nameCer, string FolderCertificates)
        {
            _installCertificates.Install(SerialNumber, nameCer, FolderCertificates);
        }

        public void InstalledCertificates() => _loaderInstalledCertificates.InstalledCertificates();

        public void InstalledCertificatesFilter(string query) => _loaderInstalledCertificates.InstalledCertificatesFilter(query);

        public void LoadCertificatesForInstall(string PathFolder) => _loaderCertificatesForInstall.CertificatesForInstall(PathFolder);
    }
}
