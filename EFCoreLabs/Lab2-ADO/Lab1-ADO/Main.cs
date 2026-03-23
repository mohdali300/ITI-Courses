namespace Lab1_ADO
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void display_Click(object sender, EventArgs e)
        {
            var form = new DisplayForm();
            form.ShowDialog();
        }

        private void add_Click(object sender, EventArgs e)
        {
            var form = new AddForm();
            form.ShowDialog();
        }
    }
}
