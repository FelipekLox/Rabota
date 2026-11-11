using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Rabota
{
    public partial class MainForm : Form
    {
        private List<Drone> drones = new List<Drone>();

        public MainForm()
        {
            InitializeComponent();
            LoadDefaultDrones();
            InitializeTypeComboBox();
            RefreshTable();
        }

        private void LoadDefaultDrones()
        {
            drones.Add(new Drone { Id = 1, Name = "Учебный №1", Model = "DJI Phantom 4 Pro", Type = "Квадрокоптер", InventoryNumber = "UAV-001", Status = "Исправен" });
            drones.Add(new Drone { Id = 2, Name = "Учебный №2", Model = "Геоскан Lite", Type = "Самолетный", InventoryNumber = "UAV-002", Status = "На обслуживании" });
            drones.Add(new Drone { Id = 3, Name = "Учебный №3", Model = "F450", Type = "Квадрокоптер", InventoryNumber = "UAV-003", Status = "Исправен" });
            drones.Add(new Drone { Id = 4, Name = "Учебный №4", Model = "Tarot T650", Type = "Гексакоптер", InventoryNumber = "UAV-004", Status = "Исправен" });
            drones.Add(new Drone { Id = 5, Name = "Учебный №5", Model = "SkyWalker X-8", Type = "Самолетный", InventoryNumber = "UAV-005", Status = "Исправен" });
        }

        private void InitializeTypeComboBox()
        {
            Control[] found = this.Controls.Find("cmbType", true);
            if (found.Length > 0 && found[0] is ComboBox cmb)
            {
                cmb.Items.Clear();
                cmb.Items.Add("Квадрокоптер");
                cmb.Items.Add("Самолетный");
                cmb.Items.Add("Гексакоптер");
                cmb.Items.Add("Вертолетный");
                cmb.SelectedIndex = 0;
            }
        }

        private void RefreshTable()
        {
            dgvDrones.DataSource = null;
            dgvDrones.DataSource = drones;
            lblTotalDrones.Text = drones.Count.ToString();
        }

        private void ClearInputFields()
        {
            if (txtDroneName != null) txtDroneName.Clear();
            if (txtModel != null) txtModel.Clear();
            if (txtStatus != null) txtStatus.Text = "Исправен";

            Control[] foundType = this.Controls.Find("cmbType", true);
            if (foundType.Length > 0 && foundType[0] is ComboBox cmb && cmb.Items.Count > 0)
                cmb.SelectedIndex = 0;

            Control[] foundInv = this.Controls.Find("txtInventoryNum", true);
            if (foundInv.Length > 0 && foundInv[0] is TextBox txt)
                txt.Clear();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                int nextId = drones.Any() ? drones.Max(d => d.Id) + 1 : 1;

                string droneType = "Квадрокоптер";
                Control[] foundType = this.Controls.Find("cmbType", true);
                if (foundType.Length > 0 && foundType[0] is ComboBox cmb)
                {
                    droneType = cmb.SelectedItem?.ToString() ?? "Квадрокоптер";
                }
ь
                string invNum = "Б/Н";
                Control[] foundInv = this.Controls.Find("txtInventoryNum", true);
                if (foundInv.Length > 0 && foundInv[0] is TextBox txt)
                {
                    invNum = string.IsNullOrWhiteSpace(txt.Text) ? "Б/Н" : txt.Text.Trim();
                }

                Drone newDrone = new Drone
                {
                    Id = nextId,
                    Name = string.IsNullOrWhiteSpace(txtDroneName?.Text) ? "Без названия" : txtDroneName.Text.Trim(),
                    Model = string.IsNullOrWhiteSpace(txtModel?.Text) ? "Неизвестная модель" : txtModel.Text.Trim(),
                    Type = droneType,
                    InventoryNumber = invNum,
                    Status = string.IsNullOrWhiteSpace(txtStatus?.Text) ? "Исправен" : txtStatus.Text.Trim()
                };

                drones.Add(newDrone);
                RefreshTable();
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при добавлении БПЛА: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch == null) return;
            string keyword = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                RefreshTable();
                return;
            }

            var filteredDrones = drones.Where(d =>
                (d.Name != null && d.Name.ToLower().Contains(keyword)) ||
                (d.Model != null && d.Model.ToLower().Contains(keyword)) ||
                (d.Type != null && d.Type.ToLower().Contains(keyword)) ||
                (d.InventoryNumber != null && d.InventoryNumber.ToLower().Contains(keyword)) ||
                (d.Status != null && d.Status.ToLower().Contains(keyword))
            ).ToList();

            dgvDrones.DataSource = null;
            dgvDrones.DataSource = filteredDrones;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvDrones.SelectedRows.Count > 0)
            {
                var selectedDrone = (Drone)dgvDrones.SelectedRows[0].DataBoundItem;
                var result = MessageBox.Show($"Вы уверены, что хотите удалить {selectedDrone.Name}?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    drones.Remove(selectedDrone);
                    RefreshTable();
                }
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите всю строку в таблице для удаления!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void lblTotalDrones_Click(object sender, EventArgs e) { }
        private void txtDroneName_TextChanged(object sender, EventArgs e) { }
        private void txtModel_TextChanged(object sender, EventArgs e) { }
        private void txtStatus_TextChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
