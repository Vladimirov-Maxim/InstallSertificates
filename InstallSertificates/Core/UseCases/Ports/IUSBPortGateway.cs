namespace InstallСertificates.Core.UseCases.Ports
{
    public interface IUSBPortGateway
    {
        public PortInfo PortInfo(string name);
        public void Connect(string addressPort);
        public void Disconnect(string addressPort);

    }
}
