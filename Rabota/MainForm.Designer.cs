namespace Rabota
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Label lblLogo;

        private System.Windows.Forms.Button btnOverview;
        private System.Windows.Forms.Button btnDrones;
        private System.Windows.Forms.Button btnParts;
        private System.Windows.Forms.Button btnMaintenance;
        private System.Windows.Forms.Button btnRules;

        private System.Windows.Forms.Label lblPageTitle;
        private System.Windows.Forms.Button btnAddDrone;

        private System.Windows.Forms.Panel cardTotal;
        private System.Windows.Forms.Label lblTotalDrones;
        private System.Windows.Forms.Panel cardReady;
        private System.Windows.Forms.Label lblReadyDrones;
        private System.Windows.Forms.Panel cardMaintenance;
        private System.Windows.Forms.Label lblMaintenanceDrones;

        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.DataGridView dgvDrones;

        private System.Windows.Forms.Button btnEditDrone;
        private System.Windows.Forms.Button btnDeleteDrone;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.lblLogo = new System.Windows.Forms.Label();
            this.btnOverview = new System.Windows.Forms.Button();
            this.btnDrones = new System.Windows.Forms.Button();
            this.btnParts = new System.Windows.Forms.Button();
            this.btnMaintenance = new System.Windows.Forms.Button();
            this.btnRules = new System.Windows.Forms.Button();

            this.panelMain = new System.Windows.Forms.Panel();
            this.lblPageTitle = new System.Windows.Forms.Label();
            this.btnAddDrone = new System.Windows.Forms.Button();

            this.cardTotal = new System.Windows.Forms.Panel();
            this.lblTotalDrones = new System.Windows.Forms.Label();
            this.cardReady = new System.Windows.Forms.Panel();
            this.lblReadyDrones = new System.Windows.Forms.Label();
            this.cardMaintenance = new System.Windows.Forms.Panel();
            this.lblMaintenanceDrones = new System.Windows.Forms.Label();

            this.txtSearch = new System.Windows.Forms.TextBox();
            this.dgvDrones = new System.Windows.Forms.DataGridView();
            this.btnEditDrone = new System.Windows.Forms.Button();
            this.btnDeleteDrone = new System.Windows.Forms.Button();

            this.panelSidebar.SuspendLayout();
            this.panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDrones)).BeginInit();
            this.SuspendLayout();

            // MainForm
            this.ClientSize = new System.Drawing.Size(1200, 750);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AeroBase — учёт БПЛА";
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelSidebar);

            // panelSidebar
            this.panelSidebar.BackColor = System.Drawing.ColorTranslator.FromHtml("#182840");
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Width = 210;
            this.panelSidebar.Controls.Add(this.lblLogo);
            this.panelSidebar.Controls.Add(this.btnOverview);
            this.panelSidebar.Controls.Add(this.btnDrones);
            this.panelSidebar.Controls.Add(this.btnParts);
            this.panelSidebar.Controls.Add(this.btnMaintenance);
            this.panelSidebar.Controls.Add(this.btnRules);

            // lblLogo
            this.lblLogo.AutoSize = true;
            this.lblLogo.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblLogo.ForeColor = System.Drawing.Color.White;
            this.lblLogo.Location = new System.Drawing.Point(20, 20);
            this.lblLogo.Text = "✈ AeroBase";

            // Кнопки меню
            SetupBtn(this.btnOverview, "Обзор", 80, false);
            SetupBtn(this.btnDrones, "Реестр БПЛА", 130, true);
            SetupBtn(this.btnParts, "Комплектующие", 180, false);
            SetupBtn(this.btnMaintenance, "Обслуживание", 230, false);
            SetupBtn(this.btnRules, "Правила", 280, false);

            // panelMain
            this.panelMain.BackColor = System.Drawing.ColorTranslator.FromHtml("#F4F7FB");
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Controls.Add(this.lblPageTitle);
            this.panelMain.Controls.Add(this.btnAddDrone);
            this.panelMain.Controls.Add(this.cardTotal);
            this.panelMain.Controls.Add(this.cardReady);
            this.panelMain.Controls.Add(this.cardMaintenance);
            this.panelMain.Controls.Add(this.txtSearch);
            this.panelMain.Controls.Add(this.dgvDrones);
            this.panelMain.Controls.Add(this.btnEditDrone);
            this.panelMain.Controls.Add(this.btnDeleteDrone);

            // lblPageTitle
            this.lblPageTitle.AutoSize = true;
            this.lblPageTitle.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblPageTitle.Location = new System.Drawing.Point(30, 25);
            this.lblPageTitle.Text = "Реестр БПЛА";

            // btnAddDrone
            this.btnAddDrone.BackColor = System.Drawing.ColorTranslator.FromHtml("#0066FF");
            this.btnAddDrone.FlatAppearance.BorderSize = 0;
            this.btnAddDrone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddDrone.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddDrone.ForeColor = System.Drawing.Color.White;
            this.btnAddDrone.Location = new System.Drawing.Point(950, 25);
            this.btnAddDrone.Size = new System.Drawing.Size(180, 38);
            this.btnAddDrone.Text = "+ Добавить БПЛА";

            // Карточки статистики
            SetupCard(this.cardTotal, "Всего БПЛА", "5", out this.lblTotalDrones, 30, 85);
            SetupCard(this.cardReady, "Исправные", "3", out this.lblReadyDrones, 260, 85);
            SetupCard(this.cardMaintenance, "На обслуживании", "2", out this.lblMaintenanceDrones, 490, 85);

            // txtSearch
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSearch.Location = new System.Drawing.Point(830, 185);
            this.txtSearch.Size = new System.Drawing.Size(300, 30);

            // dgvDrones (Таблица)
            this.dgvDrones.BackgroundColor = System.Drawing.Color.White;
            this.dgvDrones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDrones.Location = new System.Drawing.Point(30, 230);
            this.dgvDrones.Size = new System.Drawing.Size(1100, 380);
            this.dgvDrones.ReadOnly = true;
            this.dgvDrones.RowHeadersVisible = false;
            this.dgvDrones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDrones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            // Кнопки под таблицей
            this.btnEditDrone.Location = new System.Drawing.Point(30, 630);
            this.btnEditDrone.Size = new System.Drawing.Size(100, 35);
            this.btnEditDrone.Text = "Изменить";

            this.btnDeleteDrone.Location = new System.Drawing.Point(140, 630);
            this.btnDeleteDrone.Size = new System.Drawing.Size(100, 35);
            this.btnDeleteDrone.Text = "Удалить";

            this.panelSidebar.ResumeLayout(false);
            this.panelSidebar.PerformLayout();
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDrones)).EndInit();
            this.ResumeLayout(false);
        }

        private void SetupBtn(System.Windows.Forms.Button btn, string text, int top, bool active)
        {
            btn.Text = text;
            btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.ForeColor = System.Drawing.Color.White;
            btn.BackColor = active ? System.Drawing.ColorTranslator.FromHtml("#243B55") : System.Drawing.Color.Transparent;
            btn.Font = new System.Drawing.Font("Segoe UI", 10F);
            btn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btn.Padding = new System.Windows.Forms.Padding(15, 0, 0, 0);
            btn.Size = new System.Drawing.Size(210, 45);
            btn.Location = new System.Drawing.Point(0, top);
        }

        private void SetupCard(System.Windows.Forms.Panel card, string title, string val, out System.Windows.Forms.Label lblVal, int x, int y)
        {
            card.Size = new System.Drawing.Size(210, 75);
            card.Location = new System.Drawing.Point(x, y);
            card.BackColor = System.Drawing.Color.White;

            System.Windows.Forms.Label lblT = new System.Windows.Forms.Label();
            lblT.Text = title;
            lblT.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblT.ForeColor = System.Drawing.Color.Gray;
            lblT.Location = new System.Drawing.Point(15, 12);
            lblT.AutoSize = true;
            card.Controls.Add(lblT);

            lblVal = new System.Windows.Forms.Label();
            lblVal.Text = val;
            lblVal.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblVal.Location = new System.Drawing.Point(15, 32);
            lblVal.AutoSize = true;
            card.Controls.Add(lblVal);
        }
    }
}

