using InstallСertificates.Core.UseCases.Ports;

namespace InstallСertificates.InterfaceAdapters.Presenters
{
    public class MainViewPresenter : IMainViewPresenter, IMainViewOutput
    {
        
        public event Action<List<CertificateInfo>> PresentInstalledCertificates;
        public event Action<List<CertificateInfo>> PresentCertificatesForInstall;
        public event Action<string> ShowMessage;
        public event Action<string> ShowError;

        public void ShowCertificatesForInstall(List<CertificateInfo> certificates)
        {
            PresentCertificatesForInstall?.Invoke(certificates);
        }

        public void ShowInstalledCertificates(List<CertificateInfo> certificates)
        {
            PresentInstalledCertificates?.Invoke(certificates);
        }

        void IMainViewOutput.ShowError(string text) => ShowError?.Invoke(text);

        void IMainViewOutput.ShowMessage(string text) => ShowMessage?.Invoke(text);

    }
}
