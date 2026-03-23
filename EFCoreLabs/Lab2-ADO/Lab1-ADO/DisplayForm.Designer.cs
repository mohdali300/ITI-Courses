namespace Lab1_ADO
{
    partial class DisplayForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            searchBox = new TextBox();
            searchBtn = new Button();
            empGridView = new DataGridView();
            empId = new DataGridViewTextBoxColumn();
            fname = new DataGridViewTextBoxColumn();
            lname = new DataGridViewTextBoxColumn();
            salary = new DataGridViewTextBoxColumn();
            dept = new DataGridViewTextBoxColumn();
            location = new DataGridViewTextBoxColumn();
            deleteBtn = new Button();
            updateBtn = new Button();
            clearBtn = new Button();
            addBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)empGridView).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(55, 42);
            label1.Name = "label1";
            label1.Size = new Size(65, 23);
            label1.TabIndex = 0;
            label1.Text = "Search:";
            // 
            // searchBox
            // 
            searchBox.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchBox.Location = new Point(126, 39);
            searchBox.Name = "searchBox";
            searchBox.Size = new Size(200, 31);
            searchBox.TabIndex = 1;
            // 
            // searchBtn
            // 
            searchBtn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            searchBtn.Location = new Point(356, 40);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(94, 29);
            searchBtn.TabIndex = 2;
            searchBtn.Text = "search";
            searchBtn.UseVisualStyleBackColor = true;
            searchBtn.Click += searchBtn_Click;
            // 
            // empGridView
            // 
            empGridView.BackgroundColor = Color.White;
            empGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            empGridView.Columns.AddRange(new DataGridViewColumn[] { empId, fname, lname, salary, dept, location });
            empGridView.GridColor = SystemColors.ControlDark;
            empGridView.Location = new Point(19, 126);
            empGridView.Name = "empGridView";
            empGridView.RowHeadersWidth = 51;
            empGridView.Size = new Size(802, 260);
            empGridView.TabIndex = 3;
            // 
            // empId
            // 
            empId.Frozen = true;
            empId.HeaderText = "Id";
            empId.MinimumWidth = 6;
            empId.Name = "empId";
            empId.ReadOnly = true;
            empId.Width = 125;
            // 
            // fname
            // 
            fname.Frozen = true;
            fname.HeaderText = "First Name";
            fname.MinimumWidth = 6;
            fname.Name = "fname";
            fname.ReadOnly = true;
            fname.Width = 125;
            // 
            // lname
            // 
            lname.Frozen = true;
            lname.HeaderText = "Last Name";
            lname.MinimumWidth = 6;
            lname.Name = "lname";
            lname.ReadOnly = true;
            lname.Width = 125;
            // 
            // salary
            // 
            salary.Frozen = true;
            salary.HeaderText = "Salary";
            salary.MinimumWidth = 6;
            salary.Name = "salary";
            salary.ReadOnly = true;
            salary.Width = 125;
            // 
            // dept
            // 
            dept.Frozen = true;
            dept.HeaderText = "Department";
            dept.MinimumWidth = 6;
            dept.Name = "dept";
            dept.ReadOnly = true;
            dept.Width = 125;
            // 
            // location
            // 
            location.Frozen = true;
            location.HeaderText = "Location";
            location.MinimumWidth = 6;
            location.Name = "location";
            location.ReadOnly = true;
            location.Width = 125;
            // 
            // deleteBtn
            // 
            deleteBtn.BackColor = Color.LightCoral;
            deleteBtn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            deleteBtn.ForeColor = Color.Maroon;
            deleteBtn.Location = new Point(183, 417);
            deleteBtn.Name = "deleteBtn";
            deleteBtn.Size = new Size(129, 44);
            deleteBtn.TabIndex = 4;
            deleteBtn.Text = "Delete";
            deleteBtn.UseVisualStyleBackColor = false;
            deleteBtn.Click += deleteBtn_Click;
            // 
            // updateBtn
            // 
            updateBtn.BackColor = Color.SkyBlue;
            updateBtn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            updateBtn.ForeColor = Color.MidnightBlue;
            updateBtn.Location = new Point(341, 417);
            updateBtn.Name = "updateBtn";
            updateBtn.Size = new Size(129, 44);
            updateBtn.TabIndex = 5;
            updateBtn.Text = "Update";
            updateBtn.UseVisualStyleBackColor = false;
            updateBtn.Click += updateBtn_Click;
            // 
            // clearBtn
            // 
            clearBtn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            clearBtn.Location = new Point(472, 41);
            clearBtn.Name = "clearBtn";
            clearBtn.Size = new Size(94, 29);
            clearBtn.TabIndex = 6;
            clearBtn.Text = "reload";
            clearBtn.UseVisualStyleBackColor = true;
            clearBtn.Click += clearBtn_Click;
            // 
            // addBtn
            // 
            addBtn.BackColor = Color.LightGreen;
            addBtn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addBtn.ForeColor = Color.DarkGreen;
            addBtn.Location = new Point(504, 417);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(129, 44);
            addBtn.TabIndex = 7;
            addBtn.Text = "Add new";
            addBtn.UseVisualStyleBackColor = false;
            addBtn.Click += addBtn_Click;
            // 
            // DisplayForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(840, 491);
            Controls.Add(addBtn);
            Controls.Add(clearBtn);
            Controls.Add(updateBtn);
            Controls.Add(deleteBtn);
            Controls.Add(empGridView);
            Controls.Add(searchBtn);
            Controls.Add(searchBox);
            Controls.Add(label1);
            Name = "DisplayForm";
            Text = "DisplayForm";
            ((System.ComponentModel.ISupportInitialize)empGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox searchBox;
        private Button searchBtn;
        private DataGridView empGridView;
        private Button deleteBtn;
        private Button updateBtn;
        private DataGridViewTextBoxColumn empId;
        private DataGridViewTextBoxColumn fname;
        private DataGridViewTextBoxColumn lname;
        private DataGridViewTextBoxColumn salary;
        private DataGridViewTextBoxColumn dept;
        private DataGridViewTextBoxColumn location;
        private Button clearBtn;
        private Button addBtn;
    }
}