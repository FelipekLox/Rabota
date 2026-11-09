using System;
using System.Windows.Forms;

namespace Rabota
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadDataGridColumnsAndRows();
        }

        private void LoadDataGridColumnsAndRows()
        {
            dgvDrones.Columns.Clear();
            dgvDrones.Columns.Add("colName", "Название");
            dgvDrones.Columns.Add("colNumber", "Номер");
            dgvDrones.Columns.Add("colType", "Тип");
            dgvDrones.Columns.Add("colStatus", "Состояние");

            dgvDrones.Rows.Add("Учебный №1", "UAV-001", "Квадрокоптер", "Исправен");
            dgvDrones.Rows.Add("Учебный №2", "UAV-002", "Самолётный", "На обслуживании");
            dgvDrones.Rows.Add("Учебный №3", "UAV-003", "Квадрокоптер", "Исправен");
            dgvDrones.Rows.Add("Учебный №4", "UAV-004", "Гексакоптер", "Неисправен");
            dgvDrones.Rows.Add("Учебный №5", "UAV-005", "Самолётный", "Исправен");
        }
    }
}

