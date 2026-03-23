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
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
            LoadDepartments();
        }

        private void LoadDepartments()
        {
            try
            {
                var departments = DBHelper.GetDepartments();
                deptBox.DataSource = departments;
                deptBox.DisplayMember = "DeptName";
                deptBox.ValueMember = "DeptNo";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading departments: " + ex.Message);
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(fnameBox.Text) ||
               string.IsNullOrWhiteSpace(lnameBox.Text) ||
               string.IsNullOrWhiteSpace(salBox.Text) ||
               string.IsNullOrWhiteSpace(idBox.Text))
            {
                MessageBox.Show("Please fill all fields correctly.");
                return;
            }

            try
            {
                int empNo = int.Parse(idBox.Text.Trim());
                string fname = fnameBox.Text.Trim();
                string lname = lnameBox.Text.Trim();
                int salary = int.Parse(salBox.Text.Trim());
                int deptNo = (int)deptBox.SelectedValue!;
                if (DBHelper.AddEmployee(empNo, fname, lname, salary, deptNo))
                {
                    MessageBox.Show("Employee added successfully");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Failed to add employee.");
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid number for salary.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding employee: " + ex.Message);
            }
        }
    }
}
