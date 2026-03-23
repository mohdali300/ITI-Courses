namespace Lab1_ADO
{
    partial class UpdateForm
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
            deptBox = new ComboBox();
            saveBtn = new Button();
            label2 = new Label();
            label3 = new Label();
            salBox = new TextBox();
            label1 = new Label();
            lnameBox = new TextBox();
            fname = new Label();
            fnameBox = new TextBox();
            formLabel = new Label();
            SuspendLayout();
            // 
            // deptBox
            // 
            deptBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            deptBox.FormattingEnabled = true;
            deptBox.Location = new Point(439, 251);
            deptBox.Name = "deptBox";
            deptBox.Size = new Size(253, 36);
            deptBox.TabIndex = 23;
            // 
            // saveBtn
            // 
            saveBtn.BackColor = Color.PaleGreen;
            saveBtn.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            saveBtn.ForeColor = Color.DarkGreen;
            saveBtn.Location = new Point(277, 337);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(216, 62);
            saveBtn.TabIndex = 22;
            saveBtn.Text = "Save changes";
            saveBtn.UseVisualStyleBackColor = false;
            saveBtn.Click += saveBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(439, 227);
            label2.Name = "label2";
            label2.Size = new Size(106, 23);
            label2.TabIndex = 21;
            label2.Text = "Department:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(89, 227);
            label3.Name = "label3";
            label3.Size = new Size(59, 23);
            label3.TabIndex = 20;
            label3.Text = "Salary:";
            // 
            // salBox
            // 
            salBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            salBox.Location = new Point(89, 253);
            salBox.Name = "salBox";
            salBox.Size = new Size(253, 34);
            salBox.TabIndex = 19;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(439, 123);
            label1.Name = "label1";
            label1.Size = new Size(95, 23);
            label1.TabIndex = 18;
            label1.Text = "Last Name:";
            // 
            // lnameBox
            // 
            lnameBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lnameBox.Location = new Point(439, 149);
            lnameBox.Name = "lnameBox";
            lnameBox.Size = new Size(253, 34);
            lnameBox.TabIndex = 17;
            // 
            // fname
            // 
            fname.AutoSize = true;
            fname.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fname.Location = new Point(89, 123);
            fname.Name = "fname";
            fname.Size = new Size(96, 23);
            fname.TabIndex = 16;
            fname.Text = "First Name:";
            // 
            // fnameBox
            // 
            fnameBox.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            fnameBox.Location = new Point(89, 149);
            fnameBox.Name = "fnameBox";
            fnameBox.Size = new Size(253, 34);
            fnameBox.TabIndex = 15;
            // 
            // formLabel
            // 
            formLabel.AutoSize = true;
            formLabel.Font = new Font("Segoe UI Semibold", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            formLabel.Location = new Point(263, 36);
            formLabel.Name = "formLabel";
            formLabel.Size = new Size(244, 38);
            formLabel.TabIndex = 14;
            formLabel.Text = "Update Employee";
            // 
            // UpdateForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(deptBox);
            Controls.Add(saveBtn);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(salBox);
            Controls.Add(label1);
            Controls.Add(lnameBox);
            Controls.Add(fname);
            Controls.Add(fnameBox);
            Controls.Add(formLabel);
            Name = "UpdateForm";
            Text = "UpdateForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox deptBox;
        private Button saveBtn;
        private Label label2;
        private Label label3;
        private TextBox salBox;
        private Label label1;
        private TextBox lnameBox;
        private Label fname;
        private TextBox fnameBox;
        private Label formLabel;
    }
}