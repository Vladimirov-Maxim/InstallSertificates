namespace InstallSertificates.Core.UseCases.Ports
{
    public class CertificateInfo
    {

        public string Name { get; init; } = "";
        public string Subject { get; init; } = "";
        public DateTime NotBefore { get; init; }
        public DateTime NotAfter { get; init; }
        public string SerialNumber { get; init; } = "";
        public string Issuer { get; init; } = "";
        public string ContainerAddress { get; init; } = "";
        public bool Installed;

        public CertificateInfo(string subject, string issuer, string name, DateTime notAfter, DateTime notBefore, string serialNumber, bool installed)
        {
            Subject = subject;
            Issuer = issuer;
            Name = name;
            NotAfter = notAfter;
            NotBefore = notBefore;
            SerialNumber = serialNumber;
            Installed = installed;
        }

    }
}
