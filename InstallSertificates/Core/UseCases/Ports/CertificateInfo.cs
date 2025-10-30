namespace InstallСertificates.Core.UseCases.Ports
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
        public bool Installed { get; set; } = false;
        public string USBPort { get; set; } = "";

        public CertificateInfo(
            string subject,
            string issuer,
            string name,
            DateTime notAfter,
            DateTime notBefore,
            string serialNumber,
            bool installed) : this(name, subject, notBefore, notAfter, serialNumber, issuer, "", installed, "") { }

        public CertificateInfo(
            string subject,
            string issuer,
            string name,
            DateTime notAfter,
            DateTime notBefore,
            string serialNumber
            ) : this(name, subject, notBefore, notAfter, serialNumber, issuer, "", false, "") { }

        public CertificateInfo(
            string name,
            string subject,
            DateTime notBefore,
            DateTime notAfter,
            string serialNumber,
            string issuer,
            string containerAddress,
            bool installed,
            string port)
        {
            Name = name;
            Subject = subject;
            NotBefore = notBefore;
            NotAfter = notAfter;
            SerialNumber = serialNumber;
            Issuer = issuer;
            ContainerAddress = containerAddress;
            Installed = installed;
            USBPort = port;
        }
    }
}
