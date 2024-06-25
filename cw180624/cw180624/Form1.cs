using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace cw180624
{
    public partial class Form1 : Form
    {
        private List<Point> points;
        Graphics g1;
        int size = 0;
        bool sizeup = true;

        public Form1()
        {
            InitializeComponent();
            points = new List<Point>();
            this.Paint += new PaintEventHandler(Form1_Paint);
            this.MouseClick += new MouseEventHandler(Form1_MouseClick);
            g1 = CreateGraphics();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            points.Add(new Point(e.X, e.Y));
            this.Invalidate();

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen pen = new Pen(Color.Black, 2);

            foreach (Point point in points)
            {
                g.FillEllipse(Brushes.Red, point.X - 3, point.Y - 3, 6, 6);
            }

            for (int i = 0; i < points.Count - 1; i++)
            {
                g.DrawLine(pen, points[i], points[i + 1]);
            }

            if (points.Count > 2)
            {
                g.DrawLine(pen, points[points.Count - 1], points[0]);
            }

            pen.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            points.Add(new Point(int.Parse(textBox1.Text), int.Parse(textBox2.Text)));
            this.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
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
            if(size == 500)
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