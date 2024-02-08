using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Figure
{
    class Figure
    {
        public double square;
    }
    class Square : Figure
    {
        public double Side_length { get; set; }
        public Square(double side_l = 1)
        {
            this.Side_length = side_l;
            this.square = side_l * side_l;
        }
    }
    class Circle : Figure
    {
        public double Radius { get; set; }
        public Circle(double radius = 1)
        {
            this.Radius = radius;
            this.square = Math.PI * radius * radius;
        }
    }
}
