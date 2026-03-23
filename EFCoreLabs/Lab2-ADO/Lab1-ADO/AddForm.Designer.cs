namespace Lab1_ADO
{
    partial class AddForm
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
            formLabel = new Label();
            fnameBox = new TextBox();
            fname = new Label();
            label1 = new Label();
            lnameBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            salBox = new TextBox();
            addBtn = new Button();
            deptBox = new ComboBox();
            idBox = new TextBox();
            label4 = new Label();
            SuspendLayout();
            // 
            // formLabel
            // 
            formLabel.AutoSize = true;
            formLabel.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            formLabel.Location = new Point(286, 26);
            formLabel.Name = "formLabel";
            formLabel.Size = new Size(203, 38);
            formLabel.TabIndex = 1;
            formLabel.Text = "Add Employee";
            // 
            // fnameBox
            // 
            fnameBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fnameBox.Location = new Point(80, 206);
            fnameBox.Name = "fnameBox";
            fnameBox.Size = new Size(253, 34);
            fnameBox.TabIndex = 2;
            // 
            // fname
            // 
            fname.AutoSize = true;
            fname.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fname.Location = new Point(80, 180);
            fname.Name = "fname";
            fname.Size = new Size(96, 23);
            fname.TabIndex = 3;
            fname.Text = "First Name:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(430, 180);
            label1.Name = "label1";
            label1.Size = new Size(95, 23);
            label1.TabIndex = 5;
            label1.Text = "Last Name:";
            // 
            // lnameBox
            // 
            lnameBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lnameBox.Location = new Point(430, 206);
            lnameBox.Name = "lnameBox";
            lnameBox.Size = new Size(253, 34);
            lnameBox.TabIndex = 4;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(430, 264);
            label2.Name = "label2";
            label2.Size = new Size(106, 23);
            label2.TabIndex = 9;
            label2.Text = "Department:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(80, 264);
            label3.Name = "label3";
            label3.Size = new Size(59, 23);
            label3.TabIndex = 7;
            label3.Text = "Salary:";
            // 
            // salBox
            // 
            salBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            salBox.Location = new Point(80, 290);
            salBox.Name = "salBox";
            salBox.Size = new Size(253, 34);
            salBox.TabIndex = 6;
            // 
            // addBtn
            // 
            addBtn.BackColor = Color.PaleGreen;
            addBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addBtn.ForeColor = Color.DarkGreen;
            addBtn.Location = new Point(298, 368);
            addBtn.Name = "addBtn";
            addBtn.Size = new Size(158, 62);
            addBtn.TabIndex = 10;
            addBtn.Text = "+ Add";
            addBtn.UseVisualStyleBackColor = false;
            addBtn.Click += addBtn_Click;
            // 
            // deptBox
            // 
            deptBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            deptBox.FormattingEnabled = true;
            deptBox.Location = new Point(430, 288);
            deptBox.Name = "deptBox";
            deptBox.Size = new Size(253, 36);
            deptBox.TabIndex = 11;
            // 
            // idBox
            // 
            idBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            idBox.Location = new Point(252, 123);
            idBox.Name = "idBox";
            idBox.Size = new Size(253, 34);
            idBox.TabIndex = 12;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(252, 97);
            label4.Name = "label4";
            label4.Size = new Size(68, 23);
            label4.TabIndex = 13;
            label4.Text = "Emp Id:";
            // 
            // AddForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label4);
            Controls.Add(idBox);
            Controls.Add(deptBox);
            Controls.Add(addBtn);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(salBox);
            Controls.Add(label1);
            Controls.Add(lnameBox);
            Controls.Add(fname);
            Controls.Add(fnameBox);
            Controls.Add(formLabel);
            Name = "AddForm";
            Text = "AddForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label formLabel;
        private TextBox fnameBox;
        private Label fname;
        private Label label1;
        private TextBox lnameBox;
        private Label label2;
        private Label label3;
        private TextBox salBox;
        private Button addBtn;
        private ComboBox deptBox;
        private TextBox idBox;
        private Label label4;
    }
}