using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using System.Linq;


namespace CashHunt
{

    public partial class Game : Form
    {

        LinkedList<Tuple<int,string>> sentence = new LinkedList<Tuple<int, string>>();

        
        public int zaidejai = 1;
        public int pinigai = 0;
        public int suma = 0;
        public string tekstas;
        public int vieta;
        public Game()
        {
            InitializeComponent();
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            checkBox1.Checked = true;
            this.check.Multiline = true;

        }

        private void Players1Checked(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
                zaidejai = 1;
            }
            else
            {
                zaidejai = 1;
            }
        }

        private void Players2Checked(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
                zaidejai = 2;
            }
            else
            {
                zaidejai = 1;
            }
        }

        private void StartGame(object sender, EventArgs e)
        {
            GameScreen temp = new GameScreen(pinigai,zaidejai,sentence);
            this.Hide();
            temp.Show();

        }

        public void AddNodeClick(object sender, EventArgs e)
        {
            suma = Convert.ToInt32(textBox1.Text);
            tekstas = textBox2.Text.ToString();
            vieta = Convert.ToInt32(textBox3.Text);
            
            if (vieta == 1 || sentence.Count == 0)
            {
                check.Text = String.Empty;
                sentence.AddFirst(Tuple.Create(suma, tekstas));
                foreach (var item in sentence)
                {
                    check.Text += Environment.NewLine + (item.Item1).ToString() + Environment.NewLine + (item.Item2).ToString() + Environment.NewLine;
                }
                
            }

            else if (vieta >= sentence.Count + 1 )
            {
                check.Text = String.Empty;
                sentence.AddLast(Tuple.Create(suma, tekstas));
                foreach (var item in sentence)
                {
                    check.Text += Environment.NewLine+ (item.Item1).ToString() + Environment.NewLine + (item.Item2).ToString() + Environment.NewLine;
                }

                
            }

            else
            {
                LinkedListNode<Tuple<int, string>> current = sentence.First;
                for (int i = 0; i < vieta - 2; i++)
                {
                    current = current.Next;
                }
                check.Text = String.Empty;
                sentence.AddAfter(current, Tuple.Create(suma, tekstas));
                foreach (var item in sentence)
                {
                    check.Text += Environment.NewLine + (item.Item1).ToString() + Environment.NewLine + (item.Item2).ToString() + Environment.NewLine;
                }

            }

        }

        private void DeletePos(object sender, EventArgs e)
        {
            vieta = Convert.ToInt32(textBox4.Text);
            LinkedListNode<Tuple<int, string>> current = sentence.First;
            for (int i = 0; i < vieta - 1; i++)
            {
                current = current.Next;
            }
            check.Text = String.Empty;
            sentence.Remove(current);
            foreach (var item in sentence)
            {
                check.Text += Environment.NewLine + (item.Item1).ToString() + Environment.NewLine + (item.Item2).ToString() + Environment.NewLine;
            }
            


        }

        private void DeleteComment(object sender, EventArgs e)
        {
            tekstas = textBox6.Text.ToString();
            int kiekis = 0;
            LinkedListNode<Tuple<int, string>> current = sentence.First;
            while(kiekis < sentence.Count)
            {
                if(current.Value.Item2 == tekstas)
                {
                    sentence.Remove(current);
                }
                current = current.Next;
                kiekis++;
            }
            check.Text = String.Empty;

            foreach (var item in sentence)
            {
                check.Text += Environment.NewLine + (item.Item1).ToString() + Environment.NewLine + (item.Item2).ToString() + Environment.NewLine;
            }
        }

        private void BackToMenu(object sender, EventArgs e)
        {
            Application.Restart();
            DoubleBuffered = true;
        }

        private void Clear(object sender, EventArgs e)
        {
            sentence.Clear();

            check.Text = String.Empty;

        }

        private void Preload11(object sender, EventArgs e)
        {
            sentence.Clear();

            check.Text = String.Empty;

            var lines = File.ReadAllLines(@"C:\Users\miste\Desktop\CashHunt\11.csv");
            foreach(var line in lines)
            {
                var values = line.Split(',');
                suma = Convert.ToInt32(values[0]);
                tekstas = values[1].ToString();
                sentence.AddLast(Tuple.Create(suma, tekstas));
            }

            foreach (var item in sentence)
            {
                check.Text += Environment.NewLine + (item.Item1).ToString() + Environment.NewLine + (item.Item2).ToString() + Environment.NewLine;
            }
        }

        private void Preload15(object sender, EventArgs e)
        {
            sentence.Clear();

            check.Text = String.Empty;

            var lines = File.ReadAllLines(@"C:\Users\miste\Desktop\CashHunt\12.csv");
            foreach (var line in lines)
            {
                var values = line.Split(',');
                suma = Convert.ToInt32(values[0]);
                tekstas = values[1].ToString();
                sentence.AddLast(Tuple.Create(suma, tekstas));
            }

            foreach (var item in sentence)
            {
                check.Text += Environment.NewLine + (item.Item1).ToString() + Environment.NewLine + (item.Item2).ToString() + Environment.NewLine;
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void SetMoney(object sender, EventArgs e)
        {
            pinigai = Convert.ToInt32(textBox5.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Game_Load(object sender, EventArgs e)
        {

        }

        private void check_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
