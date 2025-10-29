namespace InstallSertificates.InterfaceAdapters.Controllers.Ports
{
    public interface IMainViewController
    {
        public void LoadCertificatesForInstall(string PathFolder);
        public void InstalledCertificates();
        public void InstalledCertificatesFilter(string query);


    }
}
