using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Rabota
{
    public partial class MainForm : Form
    {
        // Исправлено для старых версий C# (указан явный тип после new)
        private readonly List<Drone> drones = new List<Drone>();

        public MainForm()
        {
            InitializeComponent();
            SeedData();
            RefreshTable();
        }

        private void SeedData()
        {
            drones.Add(new Drone { Id = 1, Name = "Учебный №1", Model = "DJI Phantom 4 Pro", Type = "Квадрокоптер", InventoryNumber = "UAV-001", Status = "Исправен" });
            drones.Add(new Drone { Id = 2, Name = "Учебный №2", Model = "Геоскан-Lite", Type = "Самолётный", InventoryNumber = "UAV-002", Status = "На обслуживании" });
            drones.Add(new Drone { Id = 3, Name = "Учебный №3", Model = "Pixhawk F450", Type = "Квадрокоптер", InventoryNumber = "UAV-003", Status = "Исправен" });
            drones.Add(new Drone { Id = 4, Name = "Учебный №4", Model = "Tarot T650", Type = "Гексакоптер", InventoryNumber = "UAV-004", Status = "Неисправен" });
            drones.Add(new Drone { Id = 5, Name = "Учебный №5", Model = "SkyWalker X-8", Type = "Самолётный", InventoryNumber = "UAV-005", Status = "Исправен" });
        }

        private void UpdateStatistics()
        {
            lblTotalDrones.Text = drones.Count.ToString();
        }

        private void RefreshTable()
        {
            dgvDrones.DataSource = null;
            dgvDrones.DataSource = drones;
            UpdateStatistics();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtDroneName.Text) || string.IsNullOrWhiteSpace(txtModel.Text))
            {
                MessageBox.Show("Заполните поля Название и Модель!");
                return;
            }

            int nextId = drones.Any() ? drones.Max(d => d.Id) + 1 : 1;

            // Исправлено для старых версий C#
            Drone newDrone = new Drone()
            {
                Id = nextId,
                Name = txtDroneName.Text.Trim(),
                Model = txtModel.Text.Trim(),
                Type = "Квадрокоптер",
                InventoryNumber = "UAV-0" + nextId,
                Status = txtStatus.Text.Trim()
            };

            drones.Add(newDrone);
            RefreshTable();

            txtDroneName.Clear();
            txtModel.Clear();
            txtStatus.Text = "Исправен";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Drone selectedDrone = dgvDrones.CurrentRow?.DataBoundItem as Drone;

            if (selectedDrone == null)
            {
                MessageBox.Show("Выберите БПЛА в таблице!");
                return;
            }

            DialogResult answer = MessageBox.Show(
                $"Удалить выбранный БПЛА '{selectedDrone.Name}'?", "Подтверждение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer == DialogResult.Yes)
            {
                drones.Remove(selectedDrone);
                RefreshTable();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string query = txtSearch.Text.Trim();

            List<Drone> foundDrones = drones
                .Where(d => d.Name.Contains(query, StringComparison.OrdinalIgnoreCase) ||
                            d.Model.Contains(query, StringComparison.OrdinalIgnoreCase))
                .ToList();

            dgvDrones.DataSource = null;
            dgvDrones.DataSource = foundDrones;
        }

        private void txtDroneName_TextChanged(object sender, EventArgs e) { }
        private void txtModel_TextChanged(object sender, EventArgs e) { }
        private void txtStatus_TextChanged(object sender, EventArgs e) { }
    }
}
