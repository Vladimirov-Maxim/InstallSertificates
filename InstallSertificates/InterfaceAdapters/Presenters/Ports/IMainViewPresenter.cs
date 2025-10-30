using InstallСertificates.Core.UseCases.Ports;

namespace InstallСertificates.InterfaceAdapters.Presenters
{
    public interface IMainViewPresenter
    {
        public event Action<List<CertificateInfo>> PresentInstalledCertificates;
        public event Action<List<CertificateInfo>> PresentCertificatesForInstall;
        public event Action<string> ShowMessage;
        public event Action<string> ShowError;

    }
}
