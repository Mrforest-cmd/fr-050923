using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Algorithm;
using Encryptndecrypt;


namespace ConsoleApp3
{
    
    internal class Program
    {
        static void Main(string[] args)
        {
            /*int[,] number = {
                {5,3,2,4,1},
                {8,10,6,9,7},
                {13,15,11,14,15},
                {44,55,12,10,3},
                {53,123,12,76,11}
            };  
            Console.WriteLine(Algorithms.GetMaximumSum(number));
            Console.WriteLine(Algorithms.GetMinimumSum(number));
            Console.WriteLine(Algorithms.Difference(number));*/
            string encrypted = Safety.Encrypt("Meow", 3);
            Console.WriteLine(encrypted);
            Console.WriteLine(Safety.Decrypt(encrypted, 3));

        }
    }
}
