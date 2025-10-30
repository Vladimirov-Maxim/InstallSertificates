using InstallSertificates.Core.UseCases.Ports;

namespace InstallSertificates.Core.UseCases
{
    public class InstallCertificatesUseCase : IInstallCertificatesUseCaseInput
    {
        private ICertificatesRepository _cerRun;
        private ICertificatesGateway _certificatesGateway;
        private IUSBPortGateway _usbPortGateway;
        private IMainViewOutput _output;

        public InstallCertificatesUseCase(ICertificatesRepository cerRun,
            ICertificatesGateway certificatesGateway,
            IUSBPortGateway usbPortGateway, IMainViewOutput output)
        {
            _cerRun = cerRun;
            _certificatesGateway = certificatesGateway;
            _usbPortGateway = usbPortGateway;
            _output = output;
        }

        public void Install(string serialNumber, string nameCer, string folderCertificates)
        {

            string addressPort = string.Empty;
            bool portEnable = false;

            try
            {
                var portInfo = _usbPortGateway.PortInfo(nameCer);

                if (string.IsNullOrEmpty(portInfo.address))
                    throw new InvalidOperationException($"Не удалось найти порт c именем {nameCer}.");

                if (!string.IsNullOrEmpty(portInfo.user)
                    && !string.Equals(portInfo.user.Trim(), "you", StringComparison.OrdinalIgnoreCase))
                    throw new InvalidOperationException($"Порт занят пользователем {portInfo.user}.");

                _usbPortGateway.Connect(portInfo.address);
                portEnable = true;
                addressPort = portInfo.address;

                var container = _certificatesGateway.Install(folderCertificates, nameCer);
                if (string.IsNullOrEmpty(container))
                    throw new InvalidOperationException($"Не удалось установить сертификат.");

                var currentCer = _cerRun.Get();
                currentCer.Install(serialNumber, container, addressPort);
                _cerRun.Save(currentCer);

                var certificates = currentCer.GetCertificatesForInstall();
                _output.ShowCertificatesForInstall(certificates);

                _output.ShowMessage("Успешно");

            }
            catch (Exception ex)
            {
                _output.ShowError(ex.Message);
            } finally
            {
                if (portEnable && !string.IsNullOrEmpty(addressPort))
                    _usbPortGateway.Disconnect(addressPort);
            }

        }
    }
}
