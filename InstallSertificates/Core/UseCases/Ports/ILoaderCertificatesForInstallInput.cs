namespace InstallSertificates.Core.UseCases.Ports
{
    public interface ILoaderCertificatesForInstallInput
    {
        public void CertificatesForInstall(string PathFolder);
    }
}
