using Microsoft.Data.SqlClient;
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
        DataSet ds = new DataSet();
        DataTable empTable => ds.Tables["Employee"]!;

        public DisplayForm()
        {
            InitializeComponent();

            empGridView.AutoGenerateColumns = false;
            LoadToLocalDataSet();
        }

        private void LoadToLocalDataSet()
        {
            try
            {
                using (var con = DBHelper.GetConnection())
                {
                    string query = @"
                        SELECT e.EmpNo, e.Fname, e.Lname, e.Salary,
                               d.DeptName, d.Location, e.DeptNo
                        FROM Employee e
                        LEFT JOIN Department d ON e.DeptNo = d.DeptNo";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    ds.Clear();
                    adapter.Fill(ds, "Employee");

                    empGridView.Columns["empId"]!.DataPropertyName = "EmpNo";
                    empGridView.Columns["fname"]!.DataPropertyName = "Fname";
                    empGridView.Columns["lname"]!.DataPropertyName = "Lname";
                    empGridView.Columns["salary"]!.DataPropertyName = "Salary";
                    empGridView.Columns["dept"]!.DataPropertyName = "DeptName";
                    empGridView.Columns["location"]!.DataPropertyName = "Location";

                    empGridView.DataSource = empTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            if (empGridView.SelectedRows.Count == 0) return;

            string name = empGridView.SelectedRows[0].Cells["fname"].Value + " " +
                          empGridView.SelectedRows[0].Cells["lname"].Value;

            if (MessageBox.Show($"Delete ({name})?", "Confirm",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            int empNo = Convert.ToInt32(empGridView.SelectedRows[0].Cells["empId"].Value);

            DataRow row = empTable.Select($"EmpNo = {empNo}").FirstOrDefault()!;
            row?.Delete();
        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if (empGridView.SelectedRows.Count == 0) return;

            int empNo = Convert.ToInt32(empGridView.SelectedRows[0].Cells["empId"].Value);
            DataRow row = empTable.Select($"EmpNo = {empNo}").FirstOrDefault()!;
            if (row == null) return;

            var form = new UpdateForm(
                empNo,
                row["Fname"].ToString(),
                row["Lname"].ToString(),
                Convert.ToInt32(row["Salary"]),
                row["DeptName"].ToString()
            );

            if (form.ShowDialog() == DialogResult.OK)
            {
                row["Fname"] = form.fnameBox.Text.Trim();
                row["Lname"] = form.lnameBox.Text.Trim();
                row["Salary"] = int.Parse(form.salBox.Text.Trim());
                row["DeptNo"] = form.deptBox.SelectedValue;
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            string keyword = searchBox.Text.Trim().ToLower();
            var filtered = empTable.AsEnumerable().Where(row =>
                row["Fname"].ToString()!.ToLower().Contains(keyword) ||
                row["Lname"].ToString()!.ToLower().Contains(keyword) ||
                row["EmpNo"].ToString()!.Contains(keyword) ||
                row["DeptName"].ToString()!.ToLower().Contains(keyword)
            );

            empGridView.DataSource = filtered.Any()
                ? filtered.CopyToDataTable()
                : new DataTable();
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            searchBox.Clear();
            empGridView.DataSource = empTable;
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            var form = new AddForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                DataRow newRow = empTable.NewRow();
                newRow["EmpNo"] = int.Parse(form.idBox.Text.Trim());
                newRow["Fname"] = form.fnameBox.Text.Trim();
                newRow["Lname"] = form.lnameBox.Text.Trim();
                newRow["Salary"] = int.Parse(form.salBox.Text.Trim());
                newRow["DeptNo"] = form.deptBox.SelectedValue;
                empTable.Rows.Add(newRow);
            }
        }

        private void dbBtn_Click(object sender, EventArgs e)
        {
            try
            {
                using (var con = DBHelper.GetConnection())
                {
                    con.Open();
                    using (var transaction = con.BeginTransaction())
                    {
                        try
                        {
                            foreach (DataRow row in empTable.Rows)
                            {
                                if (row.RowState == DataRowState.Added)
                                {
                                    var cmd = new SqlCommand(
                                        "INSERT INTO Employee (Fname, Lname, Salary, DeptNo) VALUES (@f,@l,@s,@d)",
                                        con, transaction);
                                    cmd.Parameters.AddWithValue("@f", row["Fname"]);
                                    cmd.Parameters.AddWithValue("@l", row["Lname"]);
                                    cmd.Parameters.AddWithValue("@s", row["Salary"]);
                                    cmd.Parameters.AddWithValue("@d", row["DeptNo"]);
                                    cmd.ExecuteNonQuery();
                                }
                                else if (row.RowState == DataRowState.Modified)
                                {
                                    var cmd = new SqlCommand(
                                        "UPDATE Employee SET Fname=@f, Lname=@l, Salary=@s, DeptNo=@d WHERE EmpNo=@id",
                                        con, transaction);
                                    cmd.Parameters.AddWithValue("@f", row["Fname"]);
                                    cmd.Parameters.AddWithValue("@l", row["Lname"]);
                                    cmd.Parameters.AddWithValue("@s", row["Salary"]);
                                    cmd.Parameters.AddWithValue("@d", row["DeptNo"]);
                                    cmd.Parameters.AddWithValue("@id", row["EmpNo"]);
                                    cmd.ExecuteNonQuery();
                                }
                                else if (row.RowState == DataRowState.Deleted)
                                {
                                    var cmd = new SqlCommand(
                                        "DELETE FROM Employee WHERE EmpNo=@id",
                                        con, transaction);
                                    cmd.Parameters.AddWithValue("@id", row["EmpNo", DataRowVersion.Original]);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();
                            empTable.AcceptChanges();
                            MessageBox.Show("Database updated successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving to DB: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
