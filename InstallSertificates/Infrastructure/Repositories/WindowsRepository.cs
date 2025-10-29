using InstallSertificates.Core.UseCases.Ports;

namespace InstallSertificates.Infrastructure.Repositories
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
