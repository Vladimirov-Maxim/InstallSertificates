using InstallСertificates.Core.UseCases.Ports;

namespace InstallСertificates.Infrastructure.Repositories
{
    public class WindowsRepository : ILoaderCertificateForInstallRepositories
    {
        public List<string> GetCertificatesForInstall(string PathFolder)
        {

            if (!Directory.Exists(PathFolder))
                throw new FileNotFoundException($"Каталог {PathFolder} не существет.");

            var certificates = Directory.GetFiles(PathFolder, "*.cer", SearchOption.TopDirectoryOnly).ToList();
            return certificates;

        }
    }
}
