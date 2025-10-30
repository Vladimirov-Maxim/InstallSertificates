namespace InstallSertificates.InterfaceAdapters.Controllers.Ports
{
    public interface IMainViewController
    {
        public void LoadCertificatesForInstall(string PathFolder);
        public void InstalledCertificates();
        public void InstalledCertificatesFilter(string query);
        public void Install(string SerialNumber, string nameCer, string FolderCertificates);


    }
}
