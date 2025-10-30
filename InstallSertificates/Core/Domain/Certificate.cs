namespace InstallСertificates.Core.Domain
{
    public class Certificate
    {
        public string Name;
        public string Subject;
        public string Issuer;
        public DateTime NotBefore;
        public DateTime NotAfter;
        public string SerialNumber;
        public bool Installed;
        public string USBPort;
        public string ContainerAddress;

        public Certificate(
            string name,
            string subject,
            string issuer,
            DateTime notBefore,
            DateTime notAfter,
            string serialNumber,
            bool installed,
            string uSBPort,
            string containerAddress)
        {
            Name = name;
            Subject = subject;
            Issuer = issuer;
            NotBefore = notBefore;
            NotAfter = notAfter;
            SerialNumber = serialNumber;
            Installed = installed;
            USBPort = uSBPort;
            ContainerAddress = containerAddress;
        }

        public void Install(string container, string port)
        {
            Installed = true;
            ContainerAddress = container;
            USBPort = port;
        }
    }
}
