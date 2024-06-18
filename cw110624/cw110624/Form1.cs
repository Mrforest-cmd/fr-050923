using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace cw110624
{
    public partial class Form1 : Form
    {
        List<Point> points = new List<Point>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            points.Add(e.Location);
            if (points.Count == 3)
            {
                Graphics graphics = this.CreateGraphics();
                Pen pen = new Pen(Color.Black, 1);

                graphics.DrawLine(pen, points[0], points[1]);
                graphics.DrawLine(pen, points[1], points[2]);
                graphics.DrawLine(pen, points[2], points[0]);

                DrawInscribedCircle(graphics);

                UpdateLabels();

                graphics.Dispose();
                pen.Dispose();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics graphics1 = this.CreateGraphics();
            graphics1.Clear(Color.White);
            points.Clear();

            label1.Text = "";
            label2.Text = "";
            label3.Text = "";
        }

        private void UpdateLabels()
        {
            double lengthAB = Distance(points[0], points[1]);
            double lengthBC = Distance(points[1], points[2]);
            double lengthCA = Distance(points[2], points[0]);

            label1.Text = $"Points: ({points[0].X},{points[0].Y}), ({points[1].X},{points[1].Y}), ({points[2].X},{points[2].Y})\n" +
                          $"Lengths: AB={lengthAB:F2}, BC={lengthBC:F2}, CA={lengthCA:F2} (px)";

            double angleA = GetAngle(points[0], points[1], points[2]);
            double angleB = GetAngle(points[1], points[0], points[2]);
            double angleC = GetAngle(points[2], points[0], points[1]);

            label2.Text = $"Angles: A={angleA:F2}°, B={angleB:F2}°, C={angleC:F2}°";

            double area = CalculateArea(points[0], points[1], points[2]);
            label3.Text = $"Area: {area:F2} (px)";
        }

        private double GetAngle(Point p1, Point p2, Point p3)
        {
            double a = Distance(p2, p3);
            double b = Distance(p1, p3);
            double c = Distance(p1, p2);

            double angle = Math.Acos((b * b + c * c - a * a) / (2 * b * c));
            return angle * (180.0 / Math.PI);
        }

        private double Distance(Point p1, Point p2)
        {
            return Math.Sqrt((p1.X - p2.X) * (p1.X - p2.X) + (p1.Y - p2.Y) * (p1.Y - p2.Y));
        }

        private double CalculateArea(Point p1, Point p2, Point p3)
        {
            return Math.Abs(p1.X * (p2.Y - p3.Y) + p2.X * (p3.Y - p1.Y) + p3.X * (p1.Y - p2.Y)) / 2.0;
        }

        private void DrawInscribedCircle(Graphics graphics)
        {
            double a = Distance(points[1], points[2]);
            double b = Distance(points[0], points[2]);
            double c = Distance(points[0], points[1]);

            double perimeter = a + b + c;
            double s = perimeter / 2.0;

            double area = CalculateArea(points[0], points[1], points[2]);
            double radius = area / s;

            double incenterX = (a * points[0].X + b * points[1].X + c * points[2].X) / perimeter;
            double incenterY = (a * points[0].Y + b * points[1].Y + c * points[2].Y) / perimeter;

            Point incenter = new Point((int)incenterX, (int)incenterY);
            graphics.DrawEllipse(new Pen(Color.Red, 1), (int)(incenter.X - radius), (int)(incenter.Y - radius), (int)(2 * radius), (int)(2 * radius));

            label4.Text = $"Radius: {radius}, C: {2*3.14*radius*radius} (px)";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
