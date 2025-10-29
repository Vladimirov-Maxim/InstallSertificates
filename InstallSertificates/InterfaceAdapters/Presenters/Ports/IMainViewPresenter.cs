using InstallSertificates.Core.UseCases.Ports;

namespace InstallSertificates.InterfaceAdapters.Presenters
{
    public interface IMainViewPresenter
    {
        public event Action<List<CertificateInfo>> PresentInstalledCertificates;
        public event Action<List<CertificateInfo>> PresentCertificatesForInstall;

    }
}
