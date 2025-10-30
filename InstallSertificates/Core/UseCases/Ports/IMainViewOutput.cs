namespace InstallSertificates.Core.UseCases.Ports
{
    public interface IMainViewOutput
    {
        public void ShowInstalledCertificates(List<CertificateInfo> certificates);
        public void ShowCertificatesForInstall(List<CertificateInfo> certificates);
        public void ShowMessage(string text);

        public void ShowError(string text);

    }
}
