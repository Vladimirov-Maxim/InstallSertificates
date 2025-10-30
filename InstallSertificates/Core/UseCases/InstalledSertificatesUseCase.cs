using InstallSertificates.Core.UseCases.Ports;

namespace InstallSertificates.Core.UseCases
{
    public class InstalledSertificatesUseCase : IInstalledSertificatesUseCaseInput
    {

        private readonly IMainViewOutput _mainViewOutput;
        private readonly ICertificatesGateway _certificatesGateway;
        private ICertificatesRepository _certificatesRepository;

        public InstalledSertificatesUseCase(IMainViewOutput mainViewOutput, ICertificatesGateway certificatesGateway, ICertificatesRepository certificatesRepository)
        {
            _certificatesGateway = certificatesGateway;
            _mainViewOutput = mainViewOutput;
            _certificatesRepository = certificatesRepository;
        }

        public void InstalledCertificates()
        {
            var certificates = _certificatesGateway.GetCertificates();

            var cerRun = _certificatesRepository.Get();
            cerRun.LoadInstalledCertificates(certificates);
            _certificatesRepository.Save(cerRun);

            _mainViewOutput.ShowInstalledCertificates(certificates);
        }

        public void InstalledCertificatesFilter(string query)
        {
            var cerRun = _certificatesRepository.Get();
            var certificates = cerRun.GetInstalledCertificates();

            if (string.IsNullOrWhiteSpace(query))
            {
                _mainViewOutput.ShowInstalledCertificates(certificates);
                return;
            }

            string? q = query.Trim();

            bool Match(CertificateInfo c)
            {
                string haystack =
                    $"{c.Name} {c.Subject} {c.NotBefore:d} {c.NotAfter:d} {c.SerialNumber} {c.Issuer} {c.ContainerAddress}";
                return haystack.Contains(q, StringComparison.CurrentCultureIgnoreCase);
            }

            certificates = certificates.Where(Match).ToList();
            _mainViewOutput.ShowInstalledCertificates(certificates);

        }

    }

}
