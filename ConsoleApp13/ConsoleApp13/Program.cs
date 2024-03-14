using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp13
{
    class Chair
    {
        public int Number { get; set; }
        public string Color { get; set; }
        public string Person { get; set; }

        public Chair(int number, string color, string person)
        {
            Number = number;
            Color = color;
            Person = person;
        }
    }
    static class ChairUtils
    {
        public static List<Chair> GenerateChairs()
        {
            List<Chair> chairs = new List<Chair>();
            string[] colors = { "Red", "Green", "Blue" };
            string[] persons = { "Maksym", "Ivan", "Serhiy" };
            Random random = new Random();

            for (int i = 1; i <= 50; i++)
            {
                string color = colors[random.Next(colors.Length)];
                string person = persons[random.Next(persons.Length)];
                chairs.Add(new Chair(i, color, person));
            }

            return chairs;
        }

        public static List<Chair> ArrangeChairs(List<Chair> chairs)
        {
            List<Chair> arrangedChairs = new List<Chair>();
            List<Chair> redChairs = new List<Chair>();
            List<Chair> greenChairs = new List<Chair>();
            List<Chair> blueChairs = new List<Chair>();

            foreach (Chair chair in chairs)
            {
                if (chair.Color == "Red")
                    redChairs.Add(chair);
                else if (chair.Color == "Green")
                    greenChairs.Add(chair);
                else
                    blueChairs.Add(chair);
            }

            redChairs.Sort((a, b) => a.Number.CompareTo(b.Number));
            greenChairs.Sort((a, b) => a.Number.CompareTo(b.Number));
            blueChairs.Sort((a, b) => a.Number.CompareTo(b.Number));

            ArrangeByColor(arrangedChairs, redChairs, greenChairs, blueChairs);
            ArrangeByPersonName(arrangedChairs);

            return arrangedChairs;
        }

        private static void ArrangeByColor(List<Chair> arrangedChairs, List<Chair> redChairs, List<Chair> greenChairs, List<Chair> blueChairs)
        {
            foreach (Chair chair in redChairs)
                arrangedChairs.Add(chair);

            foreach (Chair chair in blueChairs)
                arrangedChairs.Add(chair);

            foreach (Chair chair in greenChairs)
                arrangedChairs.Add(chair);
        }

        private static void ArrangeByPersonName(List<Chair> arrangedChairs)
        {
            arrangedChairs.Sort((a, b) =>
            {
                if (a.Person == "Maksym" && b.Person == "Ivan")
                    return 1;
                else if (a.Person == "Ivan" && b.Person == "Maksym")
                    return -1;
                else
                    return a.Number.CompareTo(b.Number);
            });
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.UTF8;

            List<Chair> chairs = ChairUtils.GenerateChairs();
            List<Chair> arrangedChairs = ChairUtils.ArrangeChairs(chairs);

            foreach (Chair chair in chairs)
            {
                Console.WriteLine($"Chair #{chair.Number}, Color: {chair.Color}, Person: {chair.Person}");
            }
            Console.WriteLine("\n\n\n\n");
            foreach (Chair chair in arrangedChairs)
            {
                Console.WriteLine($"Chair #{chair.Number}, Color: {chair.Color}, Person: {chair.Person}");
            }
        }
    }
}