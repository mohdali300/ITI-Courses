using System;
using System.Drawing;
using System.Windows.Forms;

namespace Day9_WinForms
{
    public partial class Form1 : Form
    {
        Label companyLabel;
        MenuStrip menuStrip;

        public Form1()
        {
            InitializeComponent();
            InitializeMenu();
        }

        private void InitializeMenu()
        {
            companyLabel = new Label
            {
                Text = "Company Name",
                Font = new Font("Times New Roman", 16),
                ForeColor = Color.Black,
                AutoSize = true,
                Location = new Point(50, 50)
            };
            this.Controls.Add(companyLabel);

            menuStrip = new MenuStrip();
            ToolStripMenuItem formatMenu = new ToolStripMenuItem("Format");
            ToolStripMenuItem companyNameItem = new ToolStripMenuItem("Company Name");
            companyNameItem.Click += CompanyNameItem_Click;

            formatMenu.DropDownItems.Add(companyNameItem);
            menuStrip.Items.Add(formatMenu);
            this.MainMenuStrip = menuStrip;
            this.Controls.Add(menuStrip);
        }

        private void CompanyNameItem_Click(object sender, EventArgs e)
        {
            FormatDialog dialog = new FormatDialog(companyLabel);
            dialog.ShowDialog();
        }
    }
}