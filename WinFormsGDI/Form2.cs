using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsGDI
{
    public partial class Form2 : Form
    {
        public Form2(Form1 form1)
        {
            InitializeComponent();

            form1_ = form1;
        }

        private Form1 form1_;
        private bool draw;
        private bool drawAdiv;
        private int bX;
        private int bY;
        private Graphics g;
        public Bitmap bmap;

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            draw = false;
            drawAdiv = false;
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left))
            {
                draw = true;
                bX = e.X;
                bY = e.Y;
            }
            else if (e.Button.Equals(MouseButtons.Right))
            {
                drawAdiv = true;
                bX = e.X;
                bY = e.Y;
            }
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            g = this.CreateGraphics();
            Pen pen = form1_.penTras;
            Pen penAdiv = form1_.penTrasAdiv;
            Point pt1 = new Point(bX,bY);
            Point pt2 = new Point(e.X, e.Y);

            if (form1_.bmap != null)
            {
                this.BackgroundImage = form1_.bmap;
            }

            if (draw)
            {
                g.DrawLine(pen, pt1, pt2);

                bX = e.X;
                bY = e.Y;
            }
            else if (drawAdiv)
            {
                g.DrawLine(penAdiv, pt1, pt2);

                bX = e.X;
                bY = e.Y;
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }
    }
}
