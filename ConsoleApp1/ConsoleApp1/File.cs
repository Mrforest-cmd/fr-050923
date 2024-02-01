using System.Collections.Generic;
using System;

namespace nsp
{
    class Service
    {
        public string Title;
        public uint Price;
        public DateTime TimeTaken;

        public Service(string title_i, uint price_i, uint time_taken_i)
        {
            Title = title_i;
            Price = price_i;
            TimeTaken = DateTime.Now.AddHours(time_taken_i);
        }
    }

    class Box
    {
        private List<Service> services;
        private bool isBusy;
        private DateTime lastBusy;

        public Box()
        {
            services = new List<Service>
            {
                new Service("Change oil", 1200, 1),
                new Service("Color a thing", 1500, 5),
                new Service("Investigate", 300, 1)
            };
        }

        public void SetStatus()
        {
            isBusy = !isBusy;
        }

        public bool GetStatus()
        {
            return isBusy;
        }

        public List<Service> GetServices()
        {
            return services;
        }

        public DateTime GetTime()
        {
            return lastBusy;
        }
    }

    class CTO
    {
        private List<Box> boxes;
        private Queue<int> serviceQueue;

        public CTO()
        {
            boxes = new List<Box>();
            serviceQueue = new Queue<int>();

            for (int i = 0; i < 3; i++)
            {
                boxes.Add(new Box());
            }
        }

        public void ShowServices()
        {
            Console.WriteLine("Available services:");

            var services = boxes[0].GetServices();
            foreach (var service in services)
            {
                Console.WriteLine($"- {service.Title} ({service.Price} bubles, {service.TimeTaken} hours)");
            }

        }

        public void QueueService(ushort boxNum, int serviceIndex)
        {
            if (boxNum >= 0 && boxNum < boxes.Count)
            {
                if (!boxes[boxNum].GetStatus())
                {
                    serviceQueue.Enqueue(serviceIndex);
                    Console.WriteLine($"Service added to the queue for Box {boxNum}.");
                }
                else
                {
                    Console.WriteLine($"Box {boxNum} is busy right now, please check other boxes.");
                }
            }
            else
            {
                Console.WriteLine($"Invalid box number: {boxNum}");
            }
        }

        public void ProcessQueue()
        {
            if (serviceQueue.Count > 0)
            {
                int serviceIndex = serviceQueue.Dequeue();
                int boxIndex = serviceIndex % boxes.Count;

                Box selectedBox = boxes[boxIndex];

                if (!selectedBox.GetStatus() && DateTime.Compare(selectedBox.GetTime(),DateTime.Now) >= 0)
                {
                    selectedBox.SetStatus();
                    Console.WriteLine($"Box {boxIndex} has completed his job.");
                    selectedBox.SetStatus();
                    Console.WriteLine($"Service completed. Box {boxIndex} is now available.");
                }
                else
                {
                    Console.WriteLine($"Box {boxIndex} is still busy. Retry later." +
                        $"Time of the end: {selectedBox.GetTime()}");
                }
            }
            else
            {
                Console.WriteLine("No services in the queue.");
            }
        }
    }
}


