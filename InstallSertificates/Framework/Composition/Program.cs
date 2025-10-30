using InstallСertificates.Core.Domain;
using InstallСertificates.Core.UseCases;
using InstallСertificates.Core.UseCases.Ports;
using InstallСertificates.Infrastructure.Adapters;
using InstallСertificates.Infrastructure.Repositories;
using InstallСertificates.InterfaceAdapters.Controllers;
using InstallСertificates.InterfaceAdapters.Controllers.Ports;
using InstallСertificates.InterfaceAdapters.Presenters;
using System.Text;

namespace InstallСertificates.Framework.Composition
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
           
            try
            {

                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                // ---------- Presenters ----------
                var presenter = new MainViewPresenter();
                IMainViewPresenter viewPresenter = presenter;
                IMainViewOutput outputPort = presenter;

                // ---------- Gateways ----------
                ICertificatesGateway certificatesGateway = new CryptoProGateway();
                IUSBPortGateway usbPortGateway = new USBPortGateway();

                // ---------- Repositories ----------
                ILoaderCertificateForInstallRepositories loaderRepo = new WindowsRepository();
                ICertificatesRepository cerRun = new InMemoryCertificates();

                // ---------- Aggregates ----------
                CertificatesAggregate certificatesAggregate = new CertificatesAggregate();
                cerRun.Save(certificatesAggregate);

                // ---------- Use cases (интеракторы) ----------
                // Порядок аргументов подстрой под реальные конструкторы, идея такая:
                ILoaderCertificatesForInstallInput loaderUc =
                    new LoaderCertificateForInstallUseCase(presenter, loaderRepo, certificatesGateway, cerRun);

                IInstalledSertificatesUseCaseInput installedUc =
                    new InstalledSertificatesUseCase(presenter, certificatesGateway, cerRun);

                IInstallCertificatesUseCaseInput installCertificates =
                    new InstallCertificatesUseCase(cerRun, certificatesGateway, usbPortGateway, presenter);

                // ---------- Controller ----------
                IMainViewController controller = new MainViewController(loaderUc, installedUc, installCertificates);

                // ---------- UI ----------
                using var main = new Main(controller, viewPresenter);
                Application.Run(main);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Startup error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
