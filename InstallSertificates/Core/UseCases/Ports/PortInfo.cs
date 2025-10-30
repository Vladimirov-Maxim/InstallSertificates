namespace InstallSertificates.Core.UseCases.Ports
{
    public class PortInfo
    {
        public string address;
        public string user;

        public PortInfo()
        {
        }

        public PortInfo(string address, string user)
        {
            this.address = address;
            this.user = user;
        }
    }
}
