using System;

namespace _180124
{
    class Program
    {
        static void Main(string[] args)
        {
            uint userInput;
            Console.Write("Input a number (number > 0): ");
            userInput = Convert.ToUInt32(Console.ReadLine());
            uint limit = (uint)Math.Sqrt(userInput);

            for(uint i = 1; i < limit; i++)
            {
                if (userInput % i == 0)
                {
                    Console.WriteLine($"{i} * {userInput / i} = {userInput}");
                }

            }
        }
    }
}
/*
Користувач вводить число більше нуля ( N ). Програма виводить у консоль усі можливі варіанти множення двох цілих чисел, де результатом множення буде число N.
*/
