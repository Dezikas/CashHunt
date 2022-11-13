namespace CashHunt
{
    public partial class Meniu : Form
    {
        public Meniu()
        {
            InitializeComponent();
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void LoadGame(object sender, EventArgs e)
        {
            this.Hide();
            Game gameWindow = new Game();
            gameWindow.Show();
            DoubleBuffered = true;

        }

        private void LoadHelp(object sender, EventArgs e)
        {
            this.Hide();
            Help helpWindow = new Help();
            helpWindow.Show();
            DoubleBuffered = true;
        }

        private void Exit(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}