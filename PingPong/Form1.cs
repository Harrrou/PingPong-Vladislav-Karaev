using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PingPong
{
    public partial class Form1 : Form
    {    
        private int speed_vertical = 4;
        private int speed_hor = 4;
        private int score = 0;



        public Form1()
        {
            InitializeComponent();

            timer.Enabled = true;

            Cursor.Hide();
            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;

            this.Bounds = Screen.PrimaryScreen.Bounds;

            gamepanel.Top = Background.Bottom - (Background.Bottom / 10);



        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            gamepanel.Left = Cursor.Position.X - (gamepanel.Width / 2);

            ball.Left += speed_hor;
            ball.Top += speed_vertical;

            if (ball.Left <= Background.Left)
                speed_hor *= -1;


            if (ball.Right >= Background.Right)
                speed_hor *= -1;


            if (ball.Top <= Background.Top)
                speed_vertical *= -1;

            if (ball.Bottom >= Background.Bottom)
                timer.Enabled = false;

            if (ball.Bottom >= gamepanel.Top && ball.Bottom <= gamepanel.Bottom && ball.Left >= gamepanel.Left && ball.Right <= gamepanel.Right)
            {
                speed_hor += 3;
                speed_vertical += 3;
                speed_vertical *= -1;
                score += 1;

            }
        }
    }
}
