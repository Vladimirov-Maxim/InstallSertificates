namespace InstallСertificates.InterfaceAdapters.Controllers.Ports
{
    public interface IMainViewController
    {
        public void LoadCertificatesForInstall(string pathFolder);
        public void InstalledCertificates();
        public void InstalledCertificatesFilter(string query);
        public void Install(string serialNumber, string nameCer, string folderCertificates);


    }
}
