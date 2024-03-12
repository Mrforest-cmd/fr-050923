using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    public class Pair<T1, T2>
    {
        private T1 first;
        private T2 second;

        public Pair(T1 first, T2 second)
        {
            this.first = first;
            this.second = second;
        }

        public T1 First
        {
            get { return first; }
            set { first = value; }
        }

        public T2 Second
        {
            get { return second; }
            set { second = value; }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Pair<int, string> pair1 = new Pair<int, string>(42, "hello");
            pair1.First = 10;
            string secondValue = pair1.Second;

            Pair<bool, double> pair2 = new Pair<bool, double>(true, 3.14);
            pair2.Second = 2.718;
        }
    }
}
