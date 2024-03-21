using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter numbers separated by spaces:");
            string input = Console.ReadLine();

            List<int> numbers = input.Split(' ').Select(int.Parse).ToList();

            Console.WriteLine("Select an operation:");
            Console.WriteLine("1. Filter");
            Console.WriteLine("2. Sort");
            Console.WriteLine("3. Group");
            Console.WriteLine("4. Aggregate");
            Console.WriteLine("5. Exit");

            bool exit = false;
            while (!exit)
            {
                Console.Write("Enter your choice: ");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter filter condition (e.g., > 5): ");
                        string filterCondition = Console.ReadLine();
                        var filteredNumbers = numbers.Where(x => EvaluateCondition(x, filterCondition));
                        DisplayCollection(filteredNumbers);
                        break;

                    case 2:
                        Console.WriteLine("Select a sorting method:");
                        Console.WriteLine("1. Ascending");
                        Console.WriteLine("2. Descending");
                        Console.Write("Enter your choice: ");
                        int sortChoice = int.Parse(Console.ReadLine());

                        switch (sortChoice)
                        {
                            case 1:
                                var ascendingNumbers = numbers.OrderBy(x => x);
                                DisplayCollection(ascendingNumbers);
                                break;

                            case 2:
                                var descendingNumbers = numbers.OrderBy(x => -x);
                                DisplayCollection(descendingNumbers);
                                break;

                            default:
                                Console.WriteLine("Invalid choice. Using default ascending order.");
                                var defaultSortedNumbers = numbers.OrderBy(x => x);
                                DisplayCollection(defaultSortedNumbers);
                                break;
                        }
                        break;

                    case 3: 
                        var groupedNumbers = numbers.GroupBy(x => x % 2 == 0 ? "Even" : "Odd");
                        foreach (var group in groupedNumbers)
                        {
                            Console.WriteLine($"{group.Key} numbers: {string.Join(", ", group)}");
                        }
                        break;

                    case 4:
                        var average = numbers.Aggregate((acc, x) => x + acc) / (double)numbers.Count;
                        var sum = numbers.Aggregate((acc, x) => x + acc);
                        Console.WriteLine($"Sum: {sum}, Average: {average}");
                        break;

                    case 5: 
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static bool EvaluateCondition(int number, string condition)
        {
            string[] parts = condition.Split(' ');
            int threshold = int.Parse(parts[1]);

            switch (parts[0])
            {
                case ">":
                    return number > threshold;
                case "<":
                    return number < threshold;
                case ">=":
                    return number >= threshold;
                case "<=":
                    return number <= threshold;
                case "==":
                    return number == threshold;
                default:
                    return false;
            }
        }

        static void DisplayCollection<T>(IEnumerable<T> collection)
        {
            Console.WriteLine("Result:");
            foreach (var item in collection)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
        }
    }
}
