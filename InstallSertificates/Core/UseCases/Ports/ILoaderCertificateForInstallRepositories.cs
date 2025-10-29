using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstallSertificates.Core.UseCases.Ports
{
    public interface ILoaderCertificateForInstallRepositories
    {
        public List<string> GetCertificatesForInstall(string PathFolder);
    }
}
