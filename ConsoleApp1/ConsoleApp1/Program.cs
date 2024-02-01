using nsp;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            CTO cto = new CTO();
            bool exit = false;

            while (!exit)
            {
                //Console.Clear();
                Console.WriteLine("1. Show available services");
                Console.WriteLine("2. Queue a service");
                Console.WriteLine("3. Process service queue");
                Console.WriteLine("4. Exit");
                Console.Write("Choose an option: ");

                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            cto.ShowServices();
                            break;
                        case 2:
                            Console.Write("Enter box number: ");
                            if (ushort.TryParse(Console.ReadLine(), out ushort boxNum))
                            {
                                Console.Write("Enter service index: ");
                                if (int.TryParse(Console.ReadLine(), out int serviceIndex))
                                {
                                    cto.QueueService(boxNum, serviceIndex);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid service index.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid box number.");
                            }
                            break;
                        case 3:
                            cto.ProcessQueue();
                            break;
                        case 4:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.\n");
                }

            }
        }
    }
}
