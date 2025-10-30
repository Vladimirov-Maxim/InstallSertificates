namespace InstallСertificates.Core.UseCases.Ports
{
    public interface ILoaderCertificateForInstallRepositories
    {
        public List<string> GetCertificatesForInstall(string PathFolder);
    }
}
