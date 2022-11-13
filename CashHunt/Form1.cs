using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CashHunt
{
    public partial class Form1 : Form
    {
        public int pinigine1;
        public int pinigine2;
        public int zaidejai;
        public Form1(int pinigine1, int pinigine2, int zaidejai)
        {
            InitializeComponent();
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.pinigine1 = pinigine1;
            this.pinigine2 = pinigine2;

            tekstas();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
            DoubleBuffered = true;
        }

        public void tekstas()
        {
            if (pinigine1 > pinigine2)
            {
                label2.Text = "Player1 won";
            }
            else
            {
                label2.Text = "Player2 won";
            }

            if (zaidejai == 2)
                label1.Text = "Player1 vallet: " + pinigine1 + Environment.NewLine + "Player2 vallet: " + pinigine2;
            else
                label1.Text = "Player1 vallet: " + pinigine1;

            label2.ForeColor = Color.White;
        }
    }
}
