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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            OpenCanvas();
        }
        private Color penColor;
        private Color penAdivColor;
        private Form2 form2;
        public Pen penTras = new Pen(Color.Black, 4);
        public Pen penTrasAdiv = new Pen(Color.White, 4);
        private Pen eraser = new Pen(Color.White, 4);
        public Bitmap bmap { get; set; }

        private void OpenCanvas()
        {
            form2 = new Form2(this);
            form2.TopLevel = false;
            form2.Parent = this;
            form2.Show();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            form2.Refresh();
        }
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            string fPatch = new string(string.Empty);

            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg";

            if (open.ShowDialog() == DialogResult.OK)
            {
                fPatch = open.FileName;
                bmap = new Bitmap(fPatch);
            }
        }
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.ShowDialog();
        }
        private void toolStripDropDownButton2_Click(object sender, EventArgs e)
        {
            PrintDialog pDialog = new PrintDialog();
            pDialog.ShowDialog();
        }
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton11_Click(object sender, EventArgs e)
        {
            penColor = Color.FromArgb(toolStripButton17.BackColor.ToArgb());
            penAdivColor = Color.FromArgb(toolStripButton18.BackColor.ToArgb());

            penTras = new Pen(penColor, 4);
            penTrasAdiv = new Pen(penAdivColor, 4);
        }
        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            penTras = eraser;
            penTrasAdiv = eraser;
        }

        private void toolStripButton39_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.ShowDialog();
        }
    }
}
