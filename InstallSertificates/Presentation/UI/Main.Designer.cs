using System;
using System.Windows.Forms;

namespace InstallSertificates
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // Tabs
        private System.Windows.Forms.TabControl tabControlMain;
        private System.Windows.Forms.TabPage tabPageInstall;
        private System.Windows.Forms.TabPage tabPageInstalled;

        // Вкладка "Установка сертификатов"
        private System.Windows.Forms.TableLayoutPanel tlpInstallUpper; // верхняя полоса: Label | TextBox | "..." | "Заполнить"
        private System.Windows.Forms.Label lblFolder;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.Button btnBrowseFolder;
        private System.Windows.Forms.Button btnFill;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;

        private System.Windows.Forms.Panel panelInstallTop; // нижняя полоса с кнопкой "Установить"
        private System.Windows.Forms.Button btnInstall;

        private System.Windows.Forms.DataGridView dgvToInstall;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colToInstallSelect;   // чекбокс (первый столбец)
        private System.Windows.Forms.DataGridViewTextBoxColumn colToInstallIndex;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colToInstallFlag;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToInstallName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToInstallPort;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToInstallSubject;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToInstallNotBefore;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToInstallNotAfter;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToInstallSerial;

        // Вкладка "Установленные сертификаты"
        private System.Windows.Forms.Panel panelInstalledTop;
        private System.Windows.Forms.Button btnClearSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;

        private System.Windows.Forms.DataGridView dgvInstalled;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInstalledIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInstalledName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInstalledSubject;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInstalledNotBefore;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInstalledNotAfter;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInstalledSerial;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInstalledIssuer;
        private System.Windows.Forms.DataGridViewTextBoxColumn colInstalledContainer;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControlMain = new TabControl();
            tabPageInstall = new TabPage();
            dgvToInstall = new DataGridView();
            colToInstallSelect = new DataGridViewCheckBoxColumn();
            colToInstallIndex = new DataGridViewTextBoxColumn();
            colToInstallFlag = new DataGridViewCheckBoxColumn();
            colToInstallName = new DataGridViewTextBoxColumn();
            colToInstallPort = new DataGridViewTextBoxColumn();
            colToInstallSubject = new DataGridViewTextBoxColumn();
            colToInstallNotBefore = new DataGridViewTextBoxColumn();
            colToInstallNotAfter = new DataGridViewTextBoxColumn();
            colToInstallSerial = new DataGridViewTextBoxColumn();
            panelInstallTop = new Panel();
            btnInstall = new Button();
            tlpInstallUpper = new TableLayoutPanel();
            lblFolder = new Label();
            txtFolder = new TextBox();
            btnBrowseFolder = new Button();
            btnFill = new Button();
            tabPageInstalled = new TabPage();
            dgvInstalled = new DataGridView();
            colInstalledIndex = new DataGridViewTextBoxColumn();
            colInstalledName = new DataGridViewTextBoxColumn();
            colInstalledSubject = new DataGridViewTextBoxColumn();
            colInstalledNotBefore = new DataGridViewTextBoxColumn();
            colInstalledNotAfter = new DataGridViewTextBoxColumn();
            colInstalledSerial = new DataGridViewTextBoxColumn();
            colInstalledIssuer = new DataGridViewTextBoxColumn();
            colInstalledContainer = new DataGridViewTextBoxColumn();
            panelInstalledTop = new Panel();
            btnClearSearch = new Button();
            txtSearch = new TextBox();
            lblSearch = new Label();
            folderBrowserDialog1 = new FolderBrowserDialog();
            tabControlMain.SuspendLayout();
            tabPageInstall.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvToInstall).BeginInit();
            panelInstallTop.SuspendLayout();
            tlpInstallUpper.SuspendLayout();
            tabPageInstalled.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvInstalled).BeginInit();
            panelInstalledTop.SuspendLayout();
            SuspendLayout();
            // 
            // tabControlMain
            // 
            tabControlMain.Controls.Add(tabPageInstall);
            tabControlMain.Controls.Add(tabPageInstalled);
            tabControlMain.Dock = DockStyle.Fill;
            tabControlMain.Location = new Point(0, 0);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new Size(1280, 720);
            tabControlMain.TabIndex = 0;
            // 
            // tabPageInstall
            // 
            tabPageInstall.Controls.Add(dgvToInstall);
            tabPageInstall.Controls.Add(panelInstallTop);
            tabPageInstall.Controls.Add(tlpInstallUpper);
            tabPageInstall.Location = new Point(4, 24);
            tabPageInstall.Name = "tabPageInstall";
            tabPageInstall.Size = new Size(1272, 692);
            tabPageInstall.TabIndex = 0;
            tabPageInstall.Text = "Установка сертификатов";
            tabPageInstall.UseVisualStyleBackColor = true;
            // 
            // dgvToInstall
            // 
            dgvToInstall.AllowUserToAddRows = false;
            dgvToInstall.AllowUserToDeleteRows = false;
            dgvToInstall.AllowUserToResizeRows = false;
            dgvToInstall.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvToInstall.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dgvToInstall.Columns.AddRange(new DataGridViewColumn[] { colToInstallSelect, colToInstallIndex, colToInstallFlag, colToInstallName, colToInstallPort, colToInstallSubject, colToInstallNotBefore, colToInstallNotAfter, colToInstallSerial });
            dgvToInstall.Dock = DockStyle.Fill;
            dgvToInstall.EditMode = DataGridViewEditMode.EditOnEnter;
            dgvToInstall.Location = new Point(0, 88);
            dgvToInstall.MultiSelect = false;
            dgvToInstall.Name = "dgvToInstall";
            dgvToInstall.RowHeadersVisible = false;
            dgvToInstall.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvToInstall.Size = new Size(1272, 604);
            dgvToInstall.TabIndex = 0;

            // 
            // colToInstallSelect
            // 
            colToInstallSelect.FillWeight = 25F;
            colToInstallSelect.HeaderText = "✓";
            colToInstallSelect.MinimumWidth = 30;
            colToInstallSelect.Name = "colToInstallSelect";
            // 
            // colToInstallIndex
            // 
            colToInstallIndex.FillWeight = 30F;
            colToInstallIndex.HeaderText = "№";
            colToInstallIndex.MinimumWidth = 40;
            colToInstallIndex.Name = "colToInstallIndex";
            colToInstallIndex.ReadOnly = true;
            // 
            // colToInstallFlag
            // 
            colToInstallFlag.FillWeight = 60F;
            colToInstallFlag.HeaderText = "Установлен";
            colToInstallFlag.MinimumWidth = 60;
            colToInstallFlag.Name = "colToInstallFlag";
            colToInstallFlag.ReadOnly = true;
            // 
            // colToInstallName
            // 
            colToInstallName.FillWeight = 180F;
            colToInstallName.HeaderText = "Имя сертификата";
            colToInstallName.MinimumWidth = 120;
            colToInstallName.Name = "colToInstallName";
            colToInstallName.ReadOnly = true;
            // 
            // colToInstallPort
            // 
            colToInstallPort.FillWeight = 60F;
            colToInstallPort.HeaderText = "Порт";
            colToInstallPort.MinimumWidth = 60;
            colToInstallPort.Name = "colToInstallPort";
            colToInstallPort.ReadOnly = true;
            // 
            // colToInstallSubject
            // 
            colToInstallSubject.FillWeight = 160F;
            colToInstallSubject.HeaderText = "Субъект";
            colToInstallSubject.MinimumWidth = 120;
            colToInstallSubject.Name = "colToInstallSubject";
            colToInstallSubject.ReadOnly = true;
            // 
            // colToInstallNotBefore
            // 
            colToInstallNotBefore.FillWeight = 120F;
            colToInstallNotBefore.HeaderText = "Дата начала действия";
            colToInstallNotBefore.MinimumWidth = 120;
            colToInstallNotBefore.Name = "colToInstallNotBefore";
            colToInstallNotBefore.ReadOnly = true;
            // 
            // colToInstallNotAfter
            // 
            colToInstallNotAfter.FillWeight = 120F;
            colToInstallNotAfter.HeaderText = "Дата окончания действия";
            colToInstallNotAfter.MinimumWidth = 120;
            colToInstallNotAfter.Name = "colToInstallNotAfter";
            colToInstallNotAfter.ReadOnly = true;
            // 
            // colToInstallSerial
            // 
            colToInstallSerial.FillWeight = 140F;
            colToInstallSerial.HeaderText = "Серийный номер";
            colToInstallSerial.MinimumWidth = 120;
            colToInstallSerial.Name = "colToInstallSerial";
            colToInstallSerial.ReadOnly = true;
            // 
            // panelInstallTop
            // 
            panelInstallTop.Controls.Add(btnInstall);
            panelInstallTop.Dock = DockStyle.Top;
            panelInstallTop.Location = new Point(0, 40);
            panelInstallTop.Name = "panelInstallTop";
            panelInstallTop.Padding = new Padding(8);
            panelInstallTop.Size = new Size(1272, 48);
            panelInstallTop.TabIndex = 1;
            // 
            // btnInstall
            // 
            btnInstall.AutoSize = true;
            btnInstall.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnInstall.Dock = DockStyle.Left;
            btnInstall.Location = new Point(8, 8);
            btnInstall.Name = "btnInstall";
            btnInstall.Size = new Size(79, 32);
            btnInstall.TabIndex = 0;
            btnInstall.Text = "Установить";
            // 
            // tlpInstallUpper
            // 
            tlpInstallUpper.ColumnCount = 4;
            tlpInstallUpper.ColumnStyles.Add(new ColumnStyle());
            tlpInstallUpper.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpInstallUpper.ColumnStyles.Add(new ColumnStyle());
            tlpInstallUpper.ColumnStyles.Add(new ColumnStyle());
            tlpInstallUpper.Controls.Add(lblFolder, 0, 0);
            tlpInstallUpper.Controls.Add(txtFolder, 1, 0);
            tlpInstallUpper.Controls.Add(btnBrowseFolder, 2, 0);
            tlpInstallUpper.Controls.Add(btnFill, 3, 0);
            tlpInstallUpper.Dock = DockStyle.Top;
            tlpInstallUpper.Location = new Point(0, 0);
            tlpInstallUpper.Name = "tlpInstallUpper";
            tlpInstallUpper.Padding = new Padding(8, 6, 8, 6);
            tlpInstallUpper.RowCount = 1;
            tlpInstallUpper.RowStyles.Add(new RowStyle());
            tlpInstallUpper.Size = new Size(1272, 40);
            tlpInstallUpper.TabIndex = 2;
            // 
            // lblFolder
            // 
            lblFolder.Anchor = AnchorStyles.Left;
            lblFolder.AutoSize = true;
            lblFolder.Location = new Point(8, 12);
            lblFolder.Margin = new Padding(0, 0, 6, 0);
            lblFolder.Name = "lblFolder";
            lblFolder.Size = new Size(53, 15);
            lblFolder.TabIndex = 0;
            lblFolder.Text = "Каталог:";
            // 
            // txtFolder
            // 
            txtFolder.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtFolder.Location = new Point(67, 8);
            txtFolder.Margin = new Padding(0);
            txtFolder.Name = "txtFolder";
            txtFolder.ReadOnly = true;
            txtFolder.Size = new Size(1083, 23);
            txtFolder.TabIndex = 1;
            // 
            // btnBrowseFolder
            // 
            btnBrowseFolder.AutoSize = true;
            btnBrowseFolder.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnBrowseFolder.Location = new Point(1156, 6);
            btnBrowseFolder.Margin = new Padding(6, 0, 6, 0);
            btnBrowseFolder.Name = "btnBrowseFolder";
            btnBrowseFolder.Size = new Size(26, 25);
            btnBrowseFolder.TabIndex = 2;
            btnBrowseFolder.Text = "...";
            btnBrowseFolder.UseVisualStyleBackColor = true;
            // 
            // btnFill
            // 
            btnFill.AutoSize = true;
            btnFill.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnFill.Location = new Point(1188, 6);
            btnFill.Margin = new Padding(0);
            btnFill.Name = "btnFill";
            btnFill.Size = new Size(76, 25);
            btnFill.TabIndex = 3;
            btnFill.Text = "Заполнить";
            btnFill.UseVisualStyleBackColor = true;
            // 
            // tabPageInstalled
            // 
            tabPageInstalled.Controls.Add(dgvInstalled);
            tabPageInstalled.Controls.Add(panelInstalledTop);
            tabPageInstalled.Location = new Point(4, 24);
            tabPageInstalled.Name = "tabPageInstalled";
            tabPageInstalled.Size = new Size(1272, 692);
            tabPageInstalled.TabIndex = 1;
            tabPageInstalled.Text = "Установленные сертификаты";
            tabPageInstalled.UseVisualStyleBackColor = true;
            // 
            // dgvInstalled
            // 
            dgvInstalled.AllowUserToAddRows = false;
            dgvInstalled.AllowUserToDeleteRows = false;
            dgvInstalled.AllowUserToResizeRows = false;
            dgvInstalled.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvInstalled.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            dgvInstalled.Columns.AddRange(new DataGridViewColumn[] { colInstalledIndex, colInstalledName, colInstalledSubject, colInstalledNotBefore, colInstalledNotAfter, colInstalledSerial, colInstalledIssuer, colInstalledContainer });
            dgvInstalled.Dock = DockStyle.Fill;
            dgvInstalled.Location = new Point(0, 40);
            dgvInstalled.MultiSelect = false;
            dgvInstalled.Name = "dgvInstalled";
            dgvInstalled.ReadOnly = true;
            dgvInstalled.RowHeadersVisible = false;
            dgvInstalled.SelectionMode = DataGridViewSelectionMode.CellSelect;
            dgvInstalled.Size = new Size(1272, 652);
            dgvInstalled.TabIndex = 0;
            // 
            // colInstalledIndex
            // 
            colInstalledIndex.FillWeight = 30F;
            colInstalledIndex.HeaderText = "№";
            colInstalledIndex.MinimumWidth = 40;
            colInstalledIndex.Name = "colInstalledIndex";
            colInstalledIndex.ReadOnly = true;
            // 
            // colInstalledName
            // 
            colInstalledName.FillWeight = 160F;
            colInstalledName.HeaderText = "Имя сертификата";
            colInstalledName.MinimumWidth = 120;
            colInstalledName.Name = "colInstalledName";
            colInstalledName.ReadOnly = true;
            // 
            // colInstalledSubject
            // 
            colInstalledSubject.FillWeight = 160F;
            colInstalledSubject.HeaderText = "Субъект";
            colInstalledSubject.MinimumWidth = 120;
            colInstalledSubject.Name = "colInstalledSubject";
            colInstalledSubject.ReadOnly = true;
            // 
            // colInstalledNotBefore
            // 
            colInstalledNotBefore.FillWeight = 120F;
            colInstalledNotBefore.HeaderText = "Дата начала действия";
            colInstalledNotBefore.MinimumWidth = 120;
            colInstalledNotBefore.Name = "colInstalledNotBefore";
            colInstalledNotBefore.ReadOnly = true;
            // 
            // colInstalledNotAfter
            // 
            colInstalledNotAfter.FillWeight = 120F;
            colInstalledNotAfter.HeaderText = "Дата окончания действия";
            colInstalledNotAfter.MinimumWidth = 120;
            colInstalledNotAfter.Name = "colInstalledNotAfter";
            colInstalledNotAfter.ReadOnly = true;
            // 
            // colInstalledSerial
            // 
            colInstalledSerial.FillWeight = 140F;
            colInstalledSerial.HeaderText = "Серийный номер";
            colInstalledSerial.MinimumWidth = 120;
            colInstalledSerial.Name = "colInstalledSerial";
            colInstalledSerial.ReadOnly = true;
            // 
            // colInstalledIssuer
            // 
            colInstalledIssuer.FillWeight = 140F;
            colInstalledIssuer.HeaderText = "Кем выдан";
            colInstalledIssuer.MinimumWidth = 120;
            colInstalledIssuer.Name = "colInstalledIssuer";
            colInstalledIssuer.ReadOnly = true;
            // 
            // colInstalledContainer
            // 
            colInstalledContainer.FillWeight = 160F;
            colInstalledContainer.HeaderText = "Адрес контейнера";
            colInstalledContainer.MinimumWidth = 140;
            colInstalledContainer.Name = "colInstalledContainer";
            colInstalledContainer.ReadOnly = true;
            // 
            // panelInstalledTop
            // 
            panelInstalledTop.Controls.Add(btnClearSearch);
            panelInstalledTop.Controls.Add(txtSearch);
            panelInstalledTop.Controls.Add(lblSearch);
            panelInstalledTop.Dock = DockStyle.Top;
            panelInstalledTop.Location = new Point(0, 0);
            panelInstalledTop.Name = "panelInstalledTop";
            panelInstalledTop.Padding = new Padding(8);
            panelInstalledTop.Size = new Size(1272, 40);
            panelInstalledTop.TabIndex = 1;
            // 
            // btnClearSearch
            // 
            btnClearSearch.Cursor = Cursors.Hand;
            btnClearSearch.Dock = DockStyle.Right;
            btnClearSearch.FlatAppearance.BorderColor = Color.Gray;
            btnClearSearch.FlatAppearance.MouseDownBackColor = Color.FromArgb(224, 224, 224);
            btnClearSearch.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 240, 240);
            btnClearSearch.FlatStyle = FlatStyle.Flat;
            btnClearSearch.Location = new Point(1232, 8);
            btnClearSearch.Margin = new Padding(0);
            btnClearSearch.Name = "btnClearSearch";
            btnClearSearch.Size = new Size(32, 24);
            btnClearSearch.TabIndex = 0;
            btnClearSearch.TabStop = false;
            btnClearSearch.Text = "✕";
            btnClearSearch.Visible = false;
            // 
            // txtSearch
            // 
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Location = new Point(53, 8);
            txtSearch.Margin = new Padding(8, 6, 8, 6);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(1211, 23);
            txtSearch.TabIndex = 0;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Dock = DockStyle.Left;
            lblSearch.Location = new Point(8, 8);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(45, 15);
            lblSearch.TabIndex = 1;
            lblSearch.Text = "Поиск:";
            lblSearch.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // folderBrowserDialog1
            // 
            folderBrowserDialog1.Description = "Выберите каталог с сертификатами";
            folderBrowserDialog1.ShowNewFolderButton = false;
            // 
            // Main
            // 
            ClientSize = new Size(1280, 720);
            Controls.Add(tabControlMain);
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Установка сертификатов";
            tabControlMain.ResumeLayout(false);
            tabPageInstall.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvToInstall).EndInit();
            panelInstallTop.ResumeLayout(false);
            panelInstallTop.PerformLayout();
            tlpInstallUpper.ResumeLayout(false);
            tlpInstallUpper.PerformLayout();
            tabPageInstalled.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvInstalled).EndInit();
            panelInstalledTop.ResumeLayout(false);
            panelInstalledTop.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
    }
}
