using System;
using System.Collections.Generic;
using System.Linq;
using InstallSertificates.Core.UseCases.Ports;

namespace InstallSertificates.InterfaceAdapters.Presenters
{
    public class MainViewPresenter : IMainViewPresenter, IMainViewOutput
    {
        
        public event Action<List<CertificateInfo>> PresentInstalledCertificates;
        public event Action<List<CertificateInfo>> PresentCertificatesForInstall;

        public void ShowCertificatesForInstall(List<CertificateInfo> certificates)
        {
            PresentCertificatesForInstall?.Invoke(certificates);
        }

        public void ShowInstalledCertificates(List<CertificateInfo> certificates)
        {
            PresentInstalledCertificates?.Invoke(certificates);
        }
    }
}
