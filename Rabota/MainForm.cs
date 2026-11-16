using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Rabota
{
    public partial class MainForm : Form
    {
        private List<Drone> drones = new List<Drone>();
        private readonly DatabaseHelper _db = new DatabaseHelper();

        public MainForm()
        {
            InitializeComponent();
            InitializeTypeComboBox();
            RefreshTable();
        }

        private void InitializeTypeComboBox()
        {
            Control[] found = this.Controls.Find("cmbType", true);
            if (found.Length > 0 && found[0] is ComboBox cmb)
            {
                cmb.DropDownStyle = ComboBoxStyle.DropDown;
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
            try
            {
                drones = _db.GetDrones();
                dgvDrones.DataSource = null;
                dgvDrones.DataSource = drones;
                lblTotalDrones.Text = drones.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных из БД: " + ex.Message, "Ошибка БД", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ClearInputFields()
        {
            if (txtDroneName != null) txtDroneName.Clear();
            if (txtModel != null) txtModel.Clear();
            if (txtStatus != null) txtStatus.Text = "Исправен";

            Control[] foundType = this.Controls.Find("cmbType", true);
            if (foundType.Length > 0 && foundType[0] is ComboBox cmb)
            {
                cmb.Text = "Квадрокоптер";
            }
            else
            {
                Control[] foundTxtType = this.Controls.Find("txtType", true);
                if (foundTxtType.Length > 0 && foundTxtType[0] is TextBox txtT)
                {
                    txtT.Clear();
                }
            }

            Control[] foundInv = this.Controls.Find("txtInventoryNum", true);
            if (foundInv.Length > 0 && foundInv[0] is TextBox txt)
            {
                txt.Clear();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string droneType = "Квадрокоптер";
                Control[] foundType = this.Controls.Find("cmbType", true);
                if (foundType.Length > 0 && foundType[0] is ComboBox cmb)
                {
                    if (!string.IsNullOrWhiteSpace(cmb.Text))
                    {
                        droneType = cmb.Text.Trim();
                    }
                }
                else
                {
                    Control[] foundTxtType = this.Controls.Find("txtType", true);
                    if (foundTxtType.Length > 0 && foundTxtType[0] is TextBox txtT && !string.IsNullOrWhiteSpace(txtT.Text))
                    {
                        droneType = txtT.Text.Trim();
                    }
                }

                string invNum = "Б/Н";
                Control[] foundInv = this.Controls.Find("txtInventoryNum", true);
                if (foundInv.Length > 0 && foundInv[0] is TextBox txt)
                {
                    invNum = string.IsNullOrWhiteSpace(txt.Text) ? "Б/Н" : txt.Text.Trim();
                }

                Drone newDrone = new Drone
                {
                    Name = string.IsNullOrWhiteSpace(txtDroneName.Text) ? "Без названия" : txtDroneName.Text.Trim(),
                    Model = string.IsNullOrWhiteSpace(txtModel.Text) ? "Неизвестная модель" : txtModel.Text.Trim(),
                    Type = droneType,
                    InventoryNumber = invNum,
                    Status = string.IsNullOrWhiteSpace(txtStatus.Text) ? "Исправен" : txtStatus.Text.Trim()
                };

                // Сохраняем в PostgreSQL и обновляем таблицу
                _db.AddDrone(newDrone);
                RefreshTable();
                ClearInputFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при добавлении в БД: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    try
                    {
                        _db.DeleteDrone(selectedDrone.Id);
                        RefreshTable();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при удалении из БД: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
        private void label6_Click(object sender, EventArgs e) { }
        private void MainForm_Load(object sender, EventArgs e) { }
    }
}