namespace InstallСertificates.Core.UseCases.Ports
{
    public class PortInfo
    {
        public string address;
        public string user;

        public PortInfo()
        {
            address = string.Empty;
            user = string.Empty;
        }

        public PortInfo(string address, string user)
        {
            this.address = address;
            this.user = user;
        }
    }
}
