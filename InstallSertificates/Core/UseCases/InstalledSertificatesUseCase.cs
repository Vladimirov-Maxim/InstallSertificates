using InstallSertificates.Core.UseCases.Ports;

namespace InstallSertificates.Core.UseCases
{
    internal class InstalledSertificatesUseCase : IInstalledSertificatesUseCaseInput
    {

        private readonly IMainViewOutput _mainViewOutput;
        private readonly ICertificatesGateway _certificatesGateway;

        public InstalledSertificatesUseCase(IMainViewOutput mainViewOutput, ICertificatesGateway certificatesGateway)
        {
            _certificatesGateway = certificatesGateway;
            _mainViewOutput = mainViewOutput;
        }

        public void InstalledCertificates()
        {
            var sertificates = GetCertificates();
            _mainViewOutput.ShowInstalledCertificates(sertificates);
        }

        public void InstalledCertificatesFilter(string query)
        {

            var certificates = new List<CertificateInfo>();

           if (string.IsNullOrWhiteSpace(query))
            {
                certificates = GetCertificates();
            }
            else
            {
                var q = query.Trim();

                bool Match(CertificateInfo c)
                {

                    string haystack =
                        $"{c.Name} {c.Subject} {c.NotBefore:d} {c.NotAfter:d} {c.SerialNumber} {c.Issuer} {c.ContainerAddress}";
                    return haystack.Contains(q, StringComparison.CurrentCultureIgnoreCase);
                }

                certificates = GetCertificates().Where(Match).ToList();

            }

            _mainViewOutput.ShowInstalledCertificates(certificates);

        }

        private List<CertificateInfo> GetCertificates()
        {
            return _certificatesGateway.GetCertificates();
        }

    }

}
