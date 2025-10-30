namespace InstallСertificates.Core.UseCases.Ports
{
    public interface ICertificatesGateway
    {
        public List<CertificateInfo> GetCertificates();
        public CertificateInfo CertificateFromFile(string file);
        public string Install(string folderCertificates, string nameCer);
    }
}
