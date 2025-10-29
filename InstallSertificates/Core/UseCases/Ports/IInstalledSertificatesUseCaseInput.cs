namespace InstallSertificates.Core.UseCases.Ports
{
    public interface IInstalledSertificatesUseCaseInput
    {
        public void InstalledCertificates();
        public void InstalledCertificatesFilter(string query);
    }
}
