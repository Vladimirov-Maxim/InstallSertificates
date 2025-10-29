using InstallSertificates.Core.UseCases;
using InstallSertificates.Core.UseCases.Ports;
using InstallSertificates.Infrastructure.Adapters;
using InstallSertificates.Infrastructure.Repositories;
using InstallSertificates.InterfaceAdapters.Controllers;
using InstallSertificates.InterfaceAdapters.Controllers.Ports;
using InstallSertificates.InterfaceAdapters.Presenters;
using Microsoft.Extensions.DependencyInjection;

namespace InstallSertificates.Framework.Composition
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var services = new ServiceCollection();

            // ---------- Presenters ----------
            // Один экземпляр MainViewPresenter на два интерфейса: IMainViewPresenter и IMainViewOutput
            services.AddSingleton<MainViewPresenter>();
            services.AddSingleton<IMainViewPresenter>(sp => sp.GetRequiredService<MainViewPresenter>());
            services.AddSingleton<IMainViewOutput>(sp => sp.GetRequiredService<MainViewPresenter>());

            // ---------- Gateways ----------
            services.AddSingleton<ICertificatesGateway, X509StoreGateway>();

            // ---------- Repositories ----------
            services.AddSingleton<ILoaderCertificateForInstallRepositories, WindowsRepository>();
            services.AddSingleton<IInstallCertificatesRepository, InMemoryCertificatesForInstall>();

            // ---------- Use cases (интеракторы) ----------
            services.AddSingleton<ILoaderCertificatesForInstallInput, LoaderCertificateForInstallUseCase>();
            services.AddSingleton<IInstalledSertificatesUseCaseInput, InstalledSertificatesUseCase>();

            // ---------- Controllers ----------
            services.AddSingleton<IMainViewController, MainViewController>();

            // ---------- Forms (UI) ----------
            services.AddSingleton<Main>();


            using var sp = services.BuildServiceProvider();
            var main = sp.GetRequiredService<Main>();

            Application.Run(main);
        }
    }
}
