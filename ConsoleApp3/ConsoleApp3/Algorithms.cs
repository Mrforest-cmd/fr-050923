using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm
{
    public static class Algorithms
    {
        public static int GetMinimumSum(int[,] array)
        {
            int overallSum = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                int min = int.MaxValue;

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] < min)
                    {
                        min = array[i, j];
                    }
                }

                overallSum += min;
            }

            return overallSum;
        }
        public static int GetMaximumSum(int[,] array)
        {
            int overallSum = 0;

            for (int i = 0; i < array.GetLength(0); i++)
            {
                int min = 0;

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] > min)
                    {
                        min = array[i, j];
                    }
                }

                overallSum += min;
            }

            return overallSum;
        }

        public static int Difference(int[,] array)
        {
            return Algorithms.GetMaximumSum(array) - Algorithms.GetMinimumSum(array);
        }
    }
}
