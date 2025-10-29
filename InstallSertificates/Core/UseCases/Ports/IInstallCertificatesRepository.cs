using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstallSertificates.Core.Domain;

namespace InstallSertificates.Core.UseCases.Ports
{
    public interface IInstallCertificatesRepository
    {
        public void Save(InstallCertificates installCertificates);
        public InstallCertificates Get();
    }
}
