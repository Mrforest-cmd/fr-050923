using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Figure;
using Animal;
using geometry;


namespace ConsoleApp2
{
    

    internal class Program
    {
        static void Main(string[] args)
        {
            // Figures
            Square mysquare = new Square(15);
            Circle mycircle = new Circle(7);

            Console.WriteLine(mycircle.square);
            Console.WriteLine(mysquare.square);

            // animals

            Cat mycat = new Cat("Tom", "Mrrrr");
            Dog mydog = new Dog("Bobic", "Woaf");

            mycat.Sound();
            mydog.Sound();

            // geometry

            Polygon pentagon = new Polygon();

            Point p1 = new Point(1, 0);
            Point p2 = new Point(2, 2);
            Point p3 = new Point(0, 3);
            Point p4 = new Point(-2, 2);
            Point p5 = new Point(-1, 0);

            pentagon.AddPoint(p1);
            pentagon.AddPoint(p2);
            pentagon.AddPoint(p3);
            pentagon.AddPoint(p4);
            pentagon.AddPoint(p5);

            pentagon.Show_info();
            Console.WriteLine("Pentagon area: " + pentagon.CalculateArea());
        }
    }
}
