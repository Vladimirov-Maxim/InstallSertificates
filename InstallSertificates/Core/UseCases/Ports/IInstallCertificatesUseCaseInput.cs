namespace InstallСertificates.Core.UseCases.Ports
{
    public interface IInstallCertificatesUseCaseInput
    {

        public void Install(string SerialNumber, string nameCer, string FolderCertificates);

    }
}
