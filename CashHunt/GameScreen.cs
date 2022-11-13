namespace CashHunt
{
    public partial class GameScreen : Form
    {
        int position1 = -1;
        int position2 = -1;


        Random dice = new Random();
        public int woop;
        public int loc = 100;
        public int poc = 100;
        public int zaidejai;
        public int pinigai;
        public int kiek = 0;
        public int pinigine1;
        public int pinigine2;
        public bool start = true;
        TextBox[] arr = new TextBox[16];
        public LinkedList<Tuple<int, string>> sentence = new LinkedList<Tuple<int, string>>();
        public GameScreen(int pinigai, int zaidejai, LinkedList<Tuple<int, string>> sentence)
        {
            InitializeComponent();
            this.TopMost = true;
            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.zaidejai = zaidejai;
            this.sentence = sentence;
            this.pinigai = pinigai;
            var player1position = sentence.GetEnumerator();
            var player2position = sentence.GetEnumerator();
            player1position.MoveNext();
            player2position.MoveNext();

            zemelapis();
            kisenes();


        }


        public void button1_Click(object sender, EventArgs e)
        {
            kiek++;
            LinkedListNode<Tuple<int, string>> current = sentence.First;
            LinkedListNode<Tuple<int, string>> burrent = sentence.First;
            woop = dice.Next(1, 7);
            switch (woop)
            {
                case 1:
                    pictureBox2.ImageLocation = "dice1.png";
                    break;
                case 2:
                    pictureBox2.ImageLocation = "dice2.png";
                    break;
                case 3:
                    pictureBox2.ImageLocation = @"C:\Users\miste\Desktop\dice\dice3.png";
                    break;
                case 4:
                    pictureBox2.ImageLocation = @"C:\Users\miste\Desktop\dice\dice4.png";
                    break;
                case 5:
                    pictureBox2.ImageLocation = @"C:\Users\miste\Desktop\dice\dice5.png";
                    break;
                case 6:
                    pictureBox2.ImageLocation = @"C:\Users\miste\Desktop\dice\dice6.png";
                    break;
                default:
                    break;
            }
            if (zaidejai == 2)
            {
                if (kiek % 2 == 1)
                {
                    if(pinigai == 0 && start)
                    {
                        pinigine1 = 1000;
                        pinigine2 = 1000;
                        
                        start = false;
                    }
                    else if(start)
                    {
                        pinigine1 = pinigai;
                        pinigine2 = pinigai;

                        start = false;
                    }
                    label1.ForeColor = Color.Yellow;
                    label1.Text = "Player1";
                    if (position1 != -1)
                    {
                        arr[position1].ForeColor = Color.Black;
                        arr[position1].Font = new Font("Jost* 700", 11, FontStyle.Regular);
                    }
                        for (int i = 0; i < woop; i++)
                    {
                        position1++;
                        if (position1 >= sentence.Count)
                        {
                            position1 = -1;
                        }

                    }
                    for (int i = 0; i < position1; i++)
                    {
                            current = current.Next;
                    }

                    if (position1 != -1)
                    {
                        pinigine1 += current.Value.Item1;
                    }


                    label2.ForeColor = Color.Yellow;

                    label2.Text = "First Vallet : " + pinigine1;
                    if (position1 != -1 )
                    {
                        arr[position1].ForeColor = Color.Yellow;
                        arr[position1].Font = new Font("Jost* 700", 11, FontStyle.Bold);
                    }
                }
                else
                {
                    label1.ForeColor = Color.White;
                    label1.Text = "Player2";
                    if (position2 != -1)
                    {
                        arr[position2].ForeColor = Color.Black;
                        arr[position2].Font = new Font("Jost* 700", 11, FontStyle.Regular);
                    }
                        for (int i = 0; i < woop; i++)
                    {
                        position2++;
                        if (position2 >= sentence.Count)
                        {
                            position2 = -1;
                        }
                    }

                    for (int i = 0; i < position2; i++)
                    {
                        burrent = burrent.Next;
                    }

                    if (position2 != -1)
                    {
                        pinigine2 += burrent.Value.Item1;
                    }


                    label3.ForeColor = Color.White;
                    label3.Text = "Second Vallet : " + pinigine2;

                    if (position2 != -1 )
                    {
                        arr[position2].ForeColor = Color.White;
                        arr[position2].Font = new Font("Jost* 700", 11, FontStyle.Bold);
                    }

                }

                if(pinigine1 < 0 || pinigine2 < 0)
                {
                    Thread.Sleep(4000);
                    Form1 temp = new Form1(pinigine1, pinigine2, zaidejai);
                    this.Hide();
                    temp.Show();
                }
            }
            else
            {
                if (pinigai == 0 && start)
                {
                    pinigine1 = 1000;
                    pinigine2 = 1000;
                    label3.Text = "";

                    start = false;
                }
                else if (start)
                {
                    pinigine1 = pinigai;
                    pinigine2 = pinigai;

                    start = false;
                }
                label1.ForeColor = Color.Yellow;
                label1.Text = "Player1";
                if (position1 != -1)
                {
                    arr[position1].ForeColor = Color.Black;
                    arr[position1].Font = new Font("Jost* 700", 11, FontStyle.Regular);
                }
                for (int i = 0; i < woop; i++)
                {
                    position1++;
                    if (position1 >= sentence.Count)
                    {
                        position1 = -1;
                    }

                }
                for (int i = 0; i < position1; i++)
                {
                    current = current.Next;
                }

                if (position1 != -1)
                {
                    pinigine1 += current.Value.Item1;
                }


                label2.ForeColor = Color.Yellow;

                label2.Text = "First Vallet : " + pinigine1;
                if (position1 != -1)
                {
                    arr[position1].ForeColor = Color.Yellow;
                    arr[position1].Font = new Font("Jost* 700", 11, FontStyle.Bold);
                }
                if (pinigine1 < 0 )
                {
                    Thread.Sleep(4000);
                    Form1 temp = new Form1(pinigine1, pinigine2, zaidejai);
                    this.Hide();
                    temp.Show();
                }
            }

        }
        public void zemelapis()
        {
            

            LinkedListNode<Tuple<int, string>> current = sentence.First;

            for (int i = 0; i < sentence.Count; i++)
            {
                var _text = new TextBox();
                this.Controls.Add(_text);
                arr[i] = _text;
                if (current.Value.Item1 > 0)
                {
                    _text.BackColor = Color.Green;
                }
                else
                {
                    _text.BackColor = Color.Red;
                }
                _text.Font = new Font("Jost* 700", 11, FontStyle.Regular);
                _text.Multiline = true;
                if (sentence.Count > 11)
                {
                    if (i < 4)
                    {
                        loc += 110;
                        _text.Location = new Point(loc, poc);
                    }
                    else if (i < 8)
                    {
                        poc += 110;
                        _text.Location = new Point(loc, poc);
                    }
                    else if (i < 12)
                    {
                        loc -= 110;
                        _text.Location = new Point(loc, poc);
                    }

                    else if (i < 15)
                    {
                        poc -= 110;
                        _text.Location = new Point(loc, poc);
                    }
                }
                else if (sentence.Count < 12)
                {
                    if (i < 3)
                    {
                        loc += 110;
                        _text.Location = new Point(loc, poc);
                    }
                    else if (i < 6)
                    {
                        poc += 110;
                        _text.Location = new Point(loc, poc);
                    }
                    else if (i < 9)
                    {
                        loc -= 110;
                        _text.Location = new Point(loc, poc);
                    }

                    else if (i < 11)
                    {
                        poc -= 110;
                        _text.Location = new Point(loc, poc);
                    }
                }

                _text.Size = new Size(100, 100);
                _text.Visible = true;
                _text.TextAlign = HorizontalAlignment.Center;
                _text.Text = Environment.NewLine + (current.Value.Item1).ToString() + Environment.NewLine + Environment.NewLine + (current.Value.Item2).ToString();
                current = current.Next;
            }
        }

        private void GameScreen_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Restart();
            DoubleBuffered = true;
        }

        public void kisenes()
        {
            if (start)
            {
                if (zaidejai == 2)
                {
                    if (pinigai != 0)
                    {
                        label1.ForeColor = Color.Yellow;
                        label1.Text = "Player1";
                        label2.ForeColor = Color.Yellow;
                        label2.Text = "First Vallet : " + pinigai;
                        label3.ForeColor = Color.White;
                        label3.Text = "Second Vallet : " + pinigai;
                    }
                    else
                    {
                        label1.ForeColor = Color.Yellow;
                        label1.Text = "Player1";
                        label2.ForeColor = Color.Yellow;
                        label2.Text = "First Vallet : 1000";
                        label3.ForeColor = Color.White;
                        label3.Text = "Second Vallet : 1000";
                    }
                }
                else
                {
                    if (pinigai != 0)
                    {
                        label1.ForeColor = Color.Yellow;
                        label1.Text = "Player1";
                        label2.ForeColor = Color.Yellow;
                        label2.Text = "First Vallet : " + pinigai;
                    }
                    else
                    {
                        label1.ForeColor = Color.Yellow;
                        label1.Text = "Player1";
                        label2.ForeColor = Color.Yellow;
                        label2.Text = "First Vallet : 1000";
                    }
                }

            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
