using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool[,] dvourozmer;
        StreamReader sr = new StreamReader("zabrane_sedacky.txt", true);
        private void Form1_Load(object sender, EventArgs e)
        {
            numericUpDown1.Value = 4;
            numericUpDown2.Value = 7;
        }
        string ulozenej_text;
        Image empty = Image.FromFile("Sedacka_empty.png");
        Image full = Image.FromFile("Sedacka_full.png");
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            int x = (int)numericUpDown1.Value;
            int y = (int)numericUpDown2.Value;
            panel1.Size = new Size(50,50);
            dvourozmer = new bool[y, x];

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    panel1.Width += 50;
                    PictureBox b = new PictureBox();
                    b.Width = 50;
                    b.Height = 50;
                    b.Location = new Point(50 * j, 50 * i);
                    b.Text = ((char)((int)'A' + i)).ToString() + j;
                    b.Click += new EventHandler(this.button_Click);
                    b.BackgroundImage = empty;
                    panel1.Controls.Add(b);
                    try
                    {
                       

                        //string line;
                        //int delka_radku = sr.ReadLine().Length;
                        //string idk = "";
                        //for (int z = 0; z <= delka_radku; z++)
                        //{

                        //    sr.Read();
                        //    if (Convert.ToChar(sr.Read()) == ':') //zatím nefunguje
                        //    {

                        //        ulozenej_text = sr.ReadLine();
                        //        if (ulozenej_text == b.Text)
                        //        {
                        //            b.Enabled = false;

                        //        }
                        //    }
                        //}
                        //ulozenej_text = "";


                    }

                    catch
                    {

                    }

                }
                panel1.Height += 50;

            }
            pictureBox1.Visible = true;
            pictureBox1.Location = new System.Drawing.Point(34, (panel1.Height+12));
            pictureBox1.Width = (y * 50);
        }
        StreamWriter sw;
        private void button_Click(object sender, EventArgs e)
        {
            //sr.Close();  
            //Button btn  = sender as Button;         

            PictureBox pctrbx = sender as PictureBox;
            if (pctrbx.Image == full)
                MessageBox.Show("Tahle sedacka je zabrana!");    
            (sender as PictureBox).Image = full;
            //sw = new StreamWriter("zabrane_sedacky.txt", true);
            //sw.WriteLine();
            //sw.Write(btn.ToString()); //zatím nefunguje
            //sw.Close();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        admin admin = new admin();
        private void button2_Click(object sender, EventArgs e)
        {
            admin.ShowDialog();
        }
    }
}
