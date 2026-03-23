namespace Lab1_ADO
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            display = new Button();
            add = new Button();
            SuspendLayout();
            // 
            // display
            // 
            display.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            display.Location = new Point(247, 127);
            display.Name = "display";
            display.Size = new Size(267, 76);
            display.TabIndex = 0;
            display.Text = "Display Employees";
            display.UseVisualStyleBackColor = true;
            display.Click += display_Click;
            // 
            // add
            // 
            add.BackColor = Color.PaleGreen;
            add.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            add.ForeColor = Color.DarkGreen;
            add.Location = new Point(247, 239);
            add.Name = "add";
            add.Size = new Size(267, 76);
            add.TabIndex = 1;
            add.Text = "+ Add New Employee";
            add.UseVisualStyleBackColor = false;
            add.Click += add_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(add);
            Controls.Add(display);
            MaximizeBox = false;
            MaximumSize = new Size(818, 497);
            MinimumSize = new Size(818, 497);
            Name = "Main";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button display;
        private Button add;
    }
}
