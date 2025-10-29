namespace InstallSertificates.Core.Domain
{
    public class Certificate
    {
        public string Name { get; init; } = "";
        public string Subject { get; init; } = "";
        public DateTime NotBefore { get; init; }
        public DateTime NotAfter { get; init; }
        public string SerialNumber { get; init; } = "";
        public string Issuer { get; init; } = "";
        public string ContainerAddress { get; init; } = "";
        public bool Installed;

        public Certificate(string subject, string issuer, string name, DateTime notAfter, DateTime notBefore, string serialNumber, bool installed)
        {
            Subject = subject;
            Issuer = issuer;
            Name = name;
            NotAfter = notAfter;
            NotBefore = notBefore;
            SerialNumber = serialNumber;
            Installed = installed;
        }

        public void Install()
        {
            Installed = true;
        }

        public override bool Equals(object? obj)
        {
            return obj is Certificate info &&
                   Subject == info.Subject &&
                   Issuer == info.Issuer &&
                   Name == info.Name &&
                   NotAfter == info.NotAfter &&
                   NotBefore == info.NotBefore &&
                   SerialNumber == info.SerialNumber;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Subject, Issuer, Name, NotAfter, NotBefore, SerialNumber);
        }
    }
}
