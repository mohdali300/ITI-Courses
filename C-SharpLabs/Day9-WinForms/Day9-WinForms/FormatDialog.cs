using System;
using System.Drawing;
using System.Windows.Forms;

namespace Day9_WinForms
{
    public class FormatDialog : Form
    {
        Label targetLabel;
        TabControl tabControl;

        RadioButton rbTimesNewRoman, rbArial, rbCourier;

        RadioButton rbSize16, rbSize20, rbSize24;

        Button btnSelectColor;
        Color selectedColor;

        TextBox txtOldValue, txtNewValue;

        Button btnOK, btnCancel;

        public FormatDialog(Label label)
        {
            targetLabel = label;
            InitializeComponent();
            LoadCurrentSettings();
        }

        private void InitializeComponent()
        {
            this.Text = "Format Company Name";
            this.Size = new Size(400, 300);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            tabControl = new TabControl
            {
                Location = new Point(10, 10),
                Size = new Size(360, 200)
            };

            CreateFontTab();
            CreateSizeTab();
            CreateColorTab();
            CreateTextTab();

            this.Controls.Add(tabControl);

            btnOK = new Button
            {
                Text = "OK",
                Location = new Point(200, 220),
                Size = new Size(80, 30)
            };
            btnOK.Click += BtnOK_Click;
            this.Controls.Add(btnOK);

            btnCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(290, 220),
                Size = new Size(80, 30),
                DialogResult = DialogResult.Cancel
            };
            this.Controls.Add(btnCancel);

            this.AcceptButton = btnOK;
            this.CancelButton = btnCancel;
        }

        private void CreateFontTab()
        {
            TabPage fontTab = new TabPage("Font");

            rbTimesNewRoman = new RadioButton
            {
                Text = "Times New Roman",
                Location = new Point(20, 20),
                AutoSize = true
            };

            rbArial = new RadioButton
            {
                Text = "Arial",
                Location = new Point(20, 50),
                AutoSize = true
            };

            rbCourier = new RadioButton
            {
                Text = "Courier",
                Location = new Point(20, 80),
                AutoSize = true
            };

            fontTab.Controls.Add(rbTimesNewRoman);
            fontTab.Controls.Add(rbArial);
            fontTab.Controls.Add(rbCourier);
            tabControl.TabPages.Add(fontTab);
        }

        private void CreateSizeTab()
        {
            TabPage sizeTab = new TabPage("Size");

            rbSize16 = new RadioButton
            {
                Text = "16",
                Location = new Point(20, 20),
                AutoSize = true
            };

            rbSize20 = new RadioButton
            {
                Text = "20",
                Location = new Point(20, 50),
                AutoSize = true
            };

            rbSize24 = new RadioButton
            {
                Text = "24",
                Location = new Point(20, 80),
                AutoSize = true
            };

            sizeTab.Controls.Add(rbSize16);
            sizeTab.Controls.Add(rbSize20);
            sizeTab.Controls.Add(rbSize24);
            tabControl.TabPages.Add(sizeTab);
        }

        private void CreateColorTab()
        {
            TabPage colorTab = new TabPage("Color");

            btnSelectColor = new Button
            {
                Text = "Select Color",
                Location = new Point(20, 20),
                Size = new Size(150, 30)
            };
            btnSelectColor.Click += BtnSelectColor_Click;

            colorTab.Controls.Add(btnSelectColor);
            tabControl.TabPages.Add(colorTab);
        }

        private void CreateTextTab()
        {
            TabPage textTab = new TabPage("Text");

            Label lblOld = new Label
            {
                Text = "Old Value:",
                Location = new Point(20, 20),
                AutoSize = true
            };

            txtOldValue = new TextBox
            {
                Location = new Point(20, 45),
                Size = new Size(300, 20),
                ReadOnly = true
            };

            Label lblNew = new Label
            {
                Text = "New Value:",
                Location = new Point(20, 80),
                AutoSize = true
            };

            txtNewValue = new TextBox
            {
                Location = new Point(20, 105),
                Size = new Size(300, 20)
            };

            textTab.Controls.Add(lblOld);
            textTab.Controls.Add(txtOldValue);
            textTab.Controls.Add(lblNew);
            textTab.Controls.Add(txtNewValue);
            tabControl.TabPages.Add(textTab);
        }

        private void LoadCurrentSettings()
        {
            string fontName = targetLabel.Font.Name;
            if (fontName == "Times New Roman") rbTimesNewRoman.Checked = true;
            else if (fontName == "Arial") rbArial.Checked = true;
            else if (fontName == "Courier New" || fontName == "Courier") rbCourier.Checked = true;
            else rbTimesNewRoman.Checked = true;

            float fontSize = targetLabel.Font.Size;
            if (fontSize == 16) rbSize16.Checked = true;
            else if (fontSize == 20) rbSize20.Checked = true;
            else if (fontSize == 24) rbSize24.Checked = true;
            else rbSize16.Checked = true;

            selectedColor = targetLabel.ForeColor;

            txtOldValue.Text = targetLabel.Text;
            txtNewValue.Text = targetLabel.Text;
        }

        private void BtnSelectColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = selectedColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                selectedColor = colorDialog.Color;
                btnSelectColor.BackColor = selectedColor;
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            string fontName = "Times New Roman";
            if (rbArial.Checked) fontName = "Arial";
            else if (rbCourier.Checked) fontName = "Courier New";

            float fontSize = 16;
            if (rbSize20.Checked) fontSize = 20;
            else if (rbSize24.Checked) fontSize = 24;

            targetLabel.Font = new Font(fontName, fontSize);
            targetLabel.ForeColor = selectedColor;
            targetLabel.Text = txtNewValue.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}