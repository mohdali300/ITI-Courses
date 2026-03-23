using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1_ADO
{
    public partial class DisplayForm : Form
    {
        public DisplayForm()
        {
            InitializeComponent();

            empGridView.AutoGenerateColumns = false;
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            try
            {
                Format();
                empGridView.DataSource = DBHelper.GetAllEmployees();
                if (empGridView.Rows.Count == 0)
                    MessageBox.Show("No employees found.");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employees: " + ex.Message);
            }
        }

        private void Format()
        {
            empGridView.Columns["empId"]!.DataPropertyName = "EmpNo";
            empGridView.Columns["fname"]!.DataPropertyName = "Fname";
            empGridView.Columns["lname"]!.DataPropertyName = "Lname";
            empGridView.Columns["salary"]!.DataPropertyName = "Salary";
            empGridView.Columns["dept"]!.DataPropertyName = "DeptName";
            empGridView.Columns["location"]!.DataPropertyName = "Location";
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (empGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an employee to delete.");
            }
            else
            {
                try
                {
                    int empNo = (int)empGridView.SelectedRows[0].Cells["empId"].Value!;
                    if (DBHelper.DeleteEmployee(empNo))
                    {
                        MessageBox.Show("Employee deleted successfully.");
                        LoadEmployees();
                    }
                    else
                    {
                        MessageBox.Show("Failed to delete employee.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting employee: " + ex.Message);
                }
            }
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (empGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select an employee to update.");
                return;
            }

            var empNo = (int)empGridView.SelectedRows[0].Cells["empId"].Value!;
            var fname = (string)empGridView.SelectedRows[0].Cells["fname"].Value!;
            var lname = (string)empGridView.SelectedRows[0].Cells["lname"].Value!;
            var salary = (int)empGridView.SelectedRows[0].Cells["salary"].Value!;
            var deptName = (string)empGridView.SelectedRows[0].Cells["dept"].Value!;

            var form = new UpdateForm(empNo, fname, lname, salary, deptName);
            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadEmployees();
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string kw = searchBox.Text.Trim();
            if (string.IsNullOrEmpty(kw))
            {
                LoadEmployees();
                return;
            }
            try
            {
                Format();
                empGridView.DataSource = DBHelper.SearchEmployees(kw);
                if (empGridView.Rows.Count == 0)
                    MessageBox.Show("No employees found matching the search term.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching employees: " + ex.Message);
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
            LoadEmployees();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            var form = new AddForm();
            form.ShowDialog();
        }
    }
}
