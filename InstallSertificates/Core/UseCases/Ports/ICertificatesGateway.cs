namespace InstallSertificates.Core.UseCases.Ports
{
    public interface ICertificatesGateway
    {
        public List<CertificateInfo> GetCertificates();
        public CertificateInfo CertificateFromFile(string file);
    }
}
