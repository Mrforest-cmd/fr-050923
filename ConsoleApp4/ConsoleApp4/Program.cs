using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public static class Algorithms
    {
        public static List<object> OpenArr(List<object> arr, int pos = 0, List<object> result = null)
        {
            if(result == null)
            {
                result = new List<object>();
            }
            if (arr[pos] is int) {
                result.Add(arr[pos++]);
                return OpenArr(arr, pos, result);
            }
            if (arr[pos] is List<object>) {
                pos = 0;
                return OpenArr((List<object>)arr[pos], pos, result);
            }
            return result;
        }
        /*public static List<object> OpenArr(List<object> arr)
        {
            List<object> result = new List<object>();
            foreach (var item in arr)
            {
                if (item is List<object>)
                {
                    foreach (var variable in OpenArr((List<object>)item)) {
                        result.Add(variable);
                    }
                    //result.AddRange(OpenArr((List<object>)item));
                }
                else
                {
                    result.Add(item);
                }
            }
            return result;
        }*/
        internal class Program
        {
            static void Main(string[] args)
            {
                List<object> arr = new List<object> { 1, 2, 3, 4, 5, new List<object>{ 6, 7, 8, 9, 10, new List<object> { 11, 12, 13, 14, 15 } } };
                List<object> result = Algorithms.OpenArr(arr);
                foreach(var item in result)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
