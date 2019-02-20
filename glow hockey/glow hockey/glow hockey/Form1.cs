using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace glow_hockey
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int yerx = 5;
        int yery = 5;
        int puan = 0;
        int can = 3;
        int saniye = 60;
        int level = 1;

        private void CarpmaOLayı()
        {
            player2.Location = new Point(ball.Location.X, player2.Location.Y); // player2 ye hareket saglafık 
            // asagıda ıse player 2 ye carpma olayını ve oaun artırma ıslemını yaptık
            if (ball.Top<=player2.Bottom)
            {
                yery = yery * -1;
                puan = puan + 10;
                labelpoint.Text = puan.ToString();
            }
            if (ball.Bottom >= kontrol.Top && ball.Left >= kontrol.Left && ball.Right <= kontrol.Right)
                yery = yery * -1;

            // sag kenara carpma
            else if (ball.Right >= label7.Left)
                yerx = yerx * -1;
            // sol kenara cARPAM OLAYI
            else if (ball.Left <= label1.Right)
                yerx = yerx * -1;
            // sol alt kenara carpma olayı
            else if (ball.Bottom >= label3.Top && ball.Left <= label3.Right)
                yery = yery * -1;
            // sag alt kenara carpma olayı
            else if (ball.Bottom >= label8.Top && ball.Right >= label8.Left)
                yery = yery * -1;
            

        }
        private void YanmaOlayı(object sender, EventArgs e)
        {
            if (ball.Top>=label8.Bottom)
            {
                if (can>0)
                {
                    timer1.Stop();
                    can--;
                    timer2.Stop();
                    MessageBox.Show("Yandınız... Kalan hak =>" + can.ToString());
                    Form1_Load(sender, e);
                }
                if (can==0)
                {
                    timer1.Stop();
                    timer2.Stop();
                    MessageBox.Show("Oyun bitti"," ",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    Application.Exit();
                }
            }
            labelcan.Text = can.ToString();

        }
        private void Topbasa()
        {
            ball.Location = new Point(292,247);
            if (yery > 0)
                yery = yery * -1;
        }
        private void LevelArtıs()
        {
            saniye--;
            if (saniye==0)
            {
                level++;
                Levelduyur();
                Topbasa();
                if (yerx < 0)
                    yerx = yerx - 1;
                else 
                        yerx = yerx + 1;
                if (yery < 0)
                    yery = yery - 1;
                else
                        yery = yery + 1;
                label21.Text = level.ToString();
                saniye = 60;
            }
            labelsaniye.Text = saniye.ToString();
            labellevel.Text = level.ToString();
            



        }

        private void Levelduyur()
        {
            panel1.Visible = true;
            panel1.Location= new Point(380, 218);
            timer1.Stop();
            timer2.Stop();

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Topbasa();
            timer1.Enabled = true;
            timer2.Enabled = true;

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            kontrol.Left = e.X;
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ball.Location = new Point(ball.Location.X+yerx,ball.Location.Y+yery);
            CarpmaOLayı();
            YanmaOlayı(sender, e);
            
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            LevelArtıs();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            panel1.Visible = false;
        }
    }
}
