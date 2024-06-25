using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cw180624_2
{
    public partial class Form1 : Form
    {
        Graphics g1;
        int size = 0;
        bool sizeup = true;

        public Form1()
        {
            InitializeComponent();
            g1 = this.CreateGraphics();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            g1.Clear(Color.White);
            if (sizeup)
            {
                size += 1;
            }
            else
            {
                size -= 1;
            }
            if (size == 200)
            {
                sizeup = false;
            }
            else if (size == 0)
            {
                sizeup = true;
            }
            g1.DrawEllipse(new Pen(Color.Black), this.Width / 2 - size / 2, this.Height / 2 - size / 2, size, size);
        }
    }
}