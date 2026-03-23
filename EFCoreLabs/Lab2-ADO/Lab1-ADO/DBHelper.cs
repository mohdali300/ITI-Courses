using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1_ADO
{
    public class DBHelper
    {
        static readonly string ConnectionString =
            "Data Source=.;Initial Catalog=SD;Integrated Security=True;TrustServerCertificate=True;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }

        public static DataTable GetAllEmployees()
        {
            try
            {
                string query = @"
                SELECT e.EmpNo, e.Fname, e.Lname, e.Salary,
                       d.DeptName, d.Location
                FROM   Employee  e
                LEFT JOIN Department d ON e.DeptNo = d.DeptNo";
                return ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error fetching employees: " + ex.Message);
                return new DataTable();
            }
        }

        private static DataTable ExecuteQuery(string query)
        {
            try
            {
                var con = GetConnection();
                var adbt = new SqlDataAdapter(query, con);
                var dt = new DataTable();
                con.Open();
                adbt.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error executing query: " + ex.Message);
                return new DataTable();
            }
        }

        public static bool AddEmployee(int empNo, string fname, string lname, int salary, int deptNo)
        {
            try
            {
                string query = @"
                INSERT INTO Employee (EmpNo, Fname, Lname, Salary, DeptNo)
                VALUES (@EmpNo, @Fname, @Lname, @Salary, @DeptNo)";

                using (var con = GetConnection())
                using (var cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@EmpNo", empNo);
                    cmd.Parameters.AddWithValue("@Fname", fname);
                    cmd.Parameters.AddWithValue("@Lname", lname);
                    cmd.Parameters.AddWithValue("@Salary", salary);
                    cmd.Parameters.AddWithValue("@DeptNo", deptNo);
                    con.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding employee: " + ex.Message);
                return false;
            }
        }

        public static DataTable GetDepartments()
        {
            return ExecuteQuery("SELECT DeptNo, DeptName FROM Department");
        }

        public static bool UpdateEmployee(int empNo, string fname, string lname, int salary, int deptNo)
        {
            string query = @"
                UPDATE Employee
                SET    Fname  = @Fname,
                       Lname  = @Lname,
                       Salary = @Salary,
                       DeptNo = @DeptNo
                WHERE  EmpNo  = @EmpNo";

            using (var con = GetConnection())
            using (var cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@EmpNo", empNo);
                cmd.Parameters.AddWithValue("@Fname", fname);
                cmd.Parameters.AddWithValue("@Lname", lname);
                cmd.Parameters.AddWithValue("@Salary", salary);
                cmd.Parameters.AddWithValue("@DeptNo", deptNo);
                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public static bool DeleteEmployee(int empNo)
        {
            using (var con = GetConnection())
            using (var cmd = new SqlCommand("DELETE FROM Employee WHERE EmpNo = @EmpNo", con))
            {
                cmd.Parameters.AddWithValue("@EmpNo", empNo);
                con.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public static DataTable SearchEmployees(string keyword)
        {
            string query = @"
                SELECT e.EmpNo, e.Fname, e.Lname, e.Salary,
                       d.DeptName, d.Location
                FROM   Employee  e
                LEFT JOIN Department d ON e.DeptNo = d.DeptNo
                WHERE  e.Fname   LIKE @kw
                    OR e.Lname   LIKE @kw
                    OR CAST(e.EmpNo AS VARCHAR) LIKE @kw
                    OR d.DeptName LIKE @kw";

            using (var con = GetConnection())
            using (var cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@kw", "%" + keyword + "%");
                var adapter = new SqlDataAdapter(cmd);
                var dt = new DataTable();
                con.Open();
                adapter.Fill(dt);
                return dt;
            }
        }
    }
}
