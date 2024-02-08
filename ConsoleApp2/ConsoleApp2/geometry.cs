using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace geometry
{
    class Point
    {
        public double X;
        public double Y;
        public Point(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
        public void Move(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }
        public void Show_info()
        {
            Console.WriteLine($"Coordinates: X = {this.X}, Y = {this.Y}");
        }
    }
    class Line
    {
        public Point p1;
        public Point p2;

        public Line(Point p1, Point p2)
        {
            this.p1 = p1;
            this.p2 = p2;
        }
        public Line(double X_start, double Y_start, double X_end, double Y_end)
        {
            this.p1 = new Point(X_start, Y_start);
            this.p2 = new Point(X_end, Y_end);
        }
        public void Move_Line(double x, double y)
        {
            this.p1.X += x;
            this.p1.Y += y;

            this.p2.X += x;
            this.p2.Y += y;
        }
        public double get_length()
        {
            return Math.Sqrt(Math.Pow(p2.X - p1.X, 2) + Math.Pow(p2.Y - p1.Y, 2));
        }
        public void Show_info()
        {
            Console.WriteLine($"Points: \nCoordinates of Point 1: X = {this.p1.X}, Y = {this.p1.Y}\n" +
                $"Coordinates of Point 2: X = {this.p2.X}, Y = {this.p2.Y}");
        }
    }
    class Figure
    {
        public List<Point> points = new List<Point>(); 

        public void AddPoint(Point p)
        {
            this.points.Add(p);
        }
        public void Add_point(double x, double y)
        {
            this.points.Add(new Point(x,y));
        }
        public void Show_info()
        {
            Console.WriteLine("Points of the figure:");

            foreach (Point p in points)
            {
                Console.WriteLine($"Point: ({p.X}, {p.Y})");
            }

            Console.WriteLine("Lines of the figure:");

            for (int i = 0; i < points.Count - 1; i++)
            {
                Point pt1 = points[i];
                Point pt2 = points[i + 1];

                Console.WriteLine($"Line from ({pt1.X},{pt1.Y}) to ({pt2.X},{pt2.Y})");
            }

            Point p1 = points[points.Count - 1];
            Point p2 = points[0];

            Console.WriteLine($"Line from ({p1.X},{p1.Y}) to ({p2.X},{p2.Y})");
        }
        public void ShowLines()
        {
            for (int i = 0; i < points.Count - 1; i++)
            {
                Point pt1 = points[i];
                Point pt2 = points[i + 1];

                Console.WriteLine($"Line from ({pt1.X},{pt1.Y}) to ({pt2.X},{pt2.Y})");
            }

            Point p1 = points[points.Count - 1];
            Point p2 = points[0];

            Console.WriteLine($"Line from ({p1.X},{p1.Y}) to ({p2.X},{p2.Y})");
        }
    }
    class Polygon : Figure
    {
        public double CalculateArea()
        {
            double area = 0;

            int j = this.points.Count - 1;
            for (int i = 0; i < this.points.Count; i++)
            {
                area += (this.points[j].X + this.points[i].X) * (this.points[j].Y - this.points[i].Y);
                j = i;
            }

            return Math.Abs(area / 2);
        }
        public void Move(double xOffset, double yOffset)
        {
            foreach (Point p in points)
            {
                p.X += xOffset;
                p.Y += yOffset;
            }
        }
    }
}

/*
Геометрична бібліотека:

Створіть базовий клас Точка з властивостями X і Y. 
Створіть похідний клас Лінія, який матиме дві властивості типу Точка: Початок і Кінець. 
Реалізуйте метод визначення довжини лінії.

Створіть також клас Фігура, який має масив точок (Точка[]) як властивість. 

Створіть похідний клас Многощокутник, який буде представляти простий многощокутник та матиме метод для обчислення його площі.

Метод для зміщення:
Додайте до класу Точка метод Змістити, який дозволяє зміщувати точку на задані зміщення по вісі X та Y. 
Розширте цей метод у класі Лінія, так щоб можна було зміщувати обидві кінцеві точки лінії. 
Tакож додайте метод Змістити у клас Фігура, щоб можна було зміщувати всі точки фігури.
 
Метод для виведення інформації:Додайте метод ВивестиІнформацію у всі класи: 
Точка, Лінія, Фігура і Многощокутник. Цей метод буде виводити основну інформацію про об'єкт 
(наприклад, координати точки, координати початку і кінця лінії, або координати всіх точок у фігурі).

Додаткова функціональність:Розширте функціонал класу Многощокутник. Додайте метод для перевірки, чи є фігура квадратом. 
Також додайте можливість додавати нові точки до масиву точок фігури.

Обробка виключень:

Додайте відповідну обробку виключень для випадків, коли користувач намагається
ввести некоректні значення (наприклад, від'ємні координати). 
Використовуйте класи виключень C# для цього.
 */
