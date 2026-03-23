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
    public partial class UpdateForm : Form
    {
        private int empNo;
        public UpdateForm(int empNo, string fname, string lname, int salary, string currentDeptName)
        {
            InitializeComponent();
            LoadDepartments();

            this.empNo = empNo;
            fnameBox.Text = fname;
            lnameBox.Text = lname;
            salBox.Text = salary.ToString();
            foreach (var item in deptBox.Items)
            {
                var row = (DataRowView)item;
                if (row["DeptName"].ToString() == currentDeptName)
                {
                    deptBox.SelectedItem = item;
                    break;
                }
            }
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

        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(fname.Text) ||
                string.IsNullOrWhiteSpace(lnameBox.Text) ||
                string.IsNullOrWhiteSpace(salBox.Text))
            {
                MessageBox.Show("Please fill in all fields.", "Validation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                int deptNo = Convert.ToInt32(deptBox.SelectedValue);
                int salary = int.Parse(salBox.Text.Trim());
                if (DBHelper.UpdateEmployee(empNo, fnameBox.Text.Trim(), lnameBox.Text.Trim(), salary, deptNo))
                {
                    MessageBox.Show("Employee updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
