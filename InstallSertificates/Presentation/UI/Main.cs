using InstallSertificates.Core.UseCases.Ports;
using InstallSertificates.InterfaceAdapters.Controllers.Ports;
using InstallSertificates.InterfaceAdapters.Presenters;
using System.ComponentModel;
using Timer = System.Windows.Forms.Timer;

namespace InstallSertificates
{
    public partial class Main : Form
    {

        private IMainViewController _controller;
        private IMainViewPresenter _presenter;
        private List<CertificateInfo> _allInstalled = new();
        private readonly Timer _searchDebounce = new() { Interval = 250 };

        public Main(IMainViewController controller, IMainViewPresenter viewPresenter)
        {
            InitializeComponent();

            _controller = controller;
            _presenter = viewPresenter;

            Load += Main_Load;
            txtSearch.TextChanged += SearchTextChanged;
            btnClearSearch.Click += ClearButtonClick;
            dgvInstalled.DataBindingComplete += Dgv_DataBindingComplete;
            btnFill.Click += LoadCertificatesForInstall;

            viewPresenter.PresentInstalledCertificates += PresentInstalledCertificates;
            viewPresenter.PresentCertificatesForInstall += PresentCertificatesForInstall;

        }

        private void Main_Load(object sender, EventArgs e)
        {

            ConfigureGrids();

            _controller.InstalledCertificates();

            _searchDebounce.Tick += (_, __) => { _searchDebounce.Stop(); ApplySearch(txtSearch.Text); };
            txtSearch.TextChanged += (_, __) => { _searchDebounce.Stop(); _searchDebounce.Start(); };
            btnBrowseFolder.Click += SelectFolder;
        }

        private void ConfigureGrids()
        {

            // Установленные сертификаты

            dgvInstalled.AutoGenerateColumns = false;

            dgvInstalled.ReadOnly = true;
            dgvInstalled.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvInstalled.AllowUserToAddRows = false;
            dgvInstalled.AllowUserToDeleteRows = false;
            dgvInstalled.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvInstalled.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dgvInstalled.MultiSelect = true;

            colInstalledName.DataPropertyName = nameof(CertificateInfo.Name);
            colInstalledSubject.DataPropertyName = nameof(CertificateInfo.Subject);
            colInstalledNotBefore.DataPropertyName = nameof(CertificateInfo.NotBefore);
            colInstalledNotAfter.DataPropertyName = nameof(CertificateInfo.NotAfter);
            colInstalledSerial.DataPropertyName = nameof(CertificateInfo.SerialNumber);
            colInstalledIssuer.DataPropertyName = nameof(CertificateInfo.Issuer);

            colInstalledNotBefore.DefaultCellStyle.Format = "dd.MM.yyyy";
            colInstalledNotAfter.DefaultCellStyle.Format = "dd.MM.yyyy";

            // Сертификаты для установки

            dgvToInstall.AutoGenerateColumns = false;

            dgvToInstall.ReadOnly = true;
            dgvToInstall.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvToInstall.AllowUserToAddRows = false;
            dgvToInstall.AllowUserToDeleteRows = false;
            dgvToInstall.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvToInstall.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dgvToInstall.MultiSelect = true;

            colToInstallFlag.DataPropertyName = nameof(CertificateInfo.Installed);
            colToInstallName.DataPropertyName = nameof(CertificateInfo.Name);
            colToInstallSubject.DataPropertyName = nameof(CertificateInfo.Subject);
            colToInstallNotBefore.DataPropertyName = nameof(CertificateInfo.NotBefore);
            colToInstallNotAfter.DataPropertyName= nameof(CertificateInfo.NotAfter);
            colToInstallSerial.DataPropertyName = nameof(CertificateInfo.SerialNumber);

            colToInstallNotBefore.DefaultCellStyle.Format = "dd.MM.yyyy";
            colToInstallNotAfter.DefaultCellStyle.Format = "dd.MM.yyyy";

        }

        private void Dgv_DataBindingComplete(object? sender, DataGridViewBindingCompleteEventArgs e)
        {
            var grid = (DataGridView)sender!;

            int numberColumnIndex =
                grid == dgvToInstall ? colToInstallIndex.Index :
                grid == dgvInstalled ? colInstalledIndex.Index : -1;

            if (numberColumnIndex < 0)
                return;

            for (int i = 0; i < grid.Rows.Count; i++)
                grid.Rows[i].Cells[numberColumnIndex].Value = i + 1;
        }

        private void ClearButtonClick(object? sender, EventArgs e)
        {
            txtSearch.Clear();
            txtSearch.Focus();
        }

        private void SearchTextChanged(object? sender, EventArgs e)
        {
            btnClearSearch.Visible = txtSearch.TextLength > 0;
            _searchDebounce.Stop();
            _searchDebounce.Start();
        }

        private void ApplySearch(string query)
        {
            _controller.InstalledCertificatesFilter(query);
        }

        private void SelectFolder(object? sender, EventArgs e)
        {
            using var dialog = new FolderBrowserDialog
            {
                Description = "Выберете каталог с сертификатами",
                RootFolder = Environment.SpecialFolder.MyDocuments,
                SelectedPath = string.IsNullOrWhiteSpace(txtFolder.Text) ? null : txtFolder.Text,
                ShowNewFolderButton = false
            };

            var result = dialog.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrEmpty(dialog.SelectedPath))
            {
                txtFolder.Text = dialog.SelectedPath;
            }

        }

        private void LoadCertificatesForInstall(object? sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtFolder.Text))
                _controller.LoadCertificatesForInstall(txtFolder.Text);
        }

        private void PresentInstalledCertificates(List<CertificateInfo> certificates)
        {
            dgvInstalled.DataSource = new BindingList<CertificateInfo>(certificates);
            _allInstalled = certificates;
        }

        private void PresentCertificatesForInstall(List<CertificateInfo> certificates)
        {
            dgvToInstall.DataSource = new BindingList<CertificateInfo>(certificates);
        }

    }
}
