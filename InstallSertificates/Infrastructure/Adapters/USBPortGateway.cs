using InstallSertificates.Core.UseCases.Ports;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace InstallSertificates.Infrastructure.Adapters
{
    public class USBPortGateway : IUSBPortGateway
    {
        private string exePath = @"C:\Program Files\Distcontrol\dkcl64.exe";

        public USBPortGateway()
        {
            if (!Path.Exists(exePath))
                throw new InvalidOperationException($"Не найден исполняемый файл Distcontrol {exePath}.");
        }

        public PortInfo PortInfo(string name)
        {

            var portsInfo = PortsInfo();
            var portInfo = FindAddress(name, portsInfo);

            return portInfo;

        }

        public void Connect(string addressPort) {
            ChangeStatePort(addressPort, ActionPort.OnEnable);
            System.Threading.Thread.Sleep(1000);
        }

        public void Disconnect(string addressPort) => ChangeStatePort(addressPort, ActionPort.OnDisable);

        private void ChangeStatePort(string addressPort, ActionPort action)
        {

            var command = string.Empty;
            var message = string.Empty;

            switch (action)
            {
                case ActionPort.OnEnable:
                    command = "USE";
                    message = "подключение";
                    break;
                case ActionPort.OnDisable:
                    command = "STOP USING";
                    message = "отключение";
                    break;
                default:
                    throw new NotImplementedException("Не найдена операция над портом.");
            }

            var psi = new ProcessStartInfo(exePath)
            {
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };
            psi.ArgumentList.Add("-t");
            psi.ArgumentList.Add($"{command},{addressPort}");
            psi.ArgumentList.Add("-r");

            var tmpFile = Path.GetTempFileName();
            psi.ArgumentList.Add(tmpFile);

            var resultProcess = LocalProcess.StartProcess(psi, tmpFile);

            if (!string.Equals(resultProcess.file_out.Trim(), "OK", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(
                    $"Не удалось выполнить {message} порта, по причине:\n{resultProcess.file_out}.");
            }

        }

        private string PortsInfo()
        {
            var psi = new ProcessStartInfo(exePath)
            {
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };
            psi.ArgumentList.Add("-t");
            psi.ArgumentList.Add("LIST");
            psi.ArgumentList.Add("-r");

            var tmpFile = Path.GetTempFileName();
            psi.ArgumentList.Add(tmpFile);

            var resultProcess = LocalProcess.StartProcess(psi, tmpFile);
            return resultProcess.file_out;
  
        }

        private PortInfo FindAddress(string name, string portsInfo)
        {
            var portInfo = new PortInfo();

            var regPort = Regex.Match(portsInfo, $"(?<={name}).*", RegexOptions.IgnoreCase);
            if (!regPort.Success)
                return portInfo;

            try
            {
                var regInfo = Regex.Match(regPort.Value, @"\((?<address>[^()]*)\)(?:\s*\(.*use\s+by\s+(?<user>[^()]*)\s*\))?");

                if (!regInfo.Success)
                    return portInfo;

                portInfo.address = regInfo.Groups["address"].Value;
                portInfo.user = regInfo.Groups["user"].Value;

                return portInfo;

            } catch
            {
                return portInfo;
            }
        }

        public enum ActionPort
        {
            OnEnable,
            OnDisable
        }
    }
}
