using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CM
{
    public class CollectionManager<T>
    {
        private List<T> collection;

        public CollectionManager()
        {
            collection = new List<T>();
        }

        public void AddItem(T item)
        {
            collection.Add(item);
            Console.WriteLine($"Елемент {item} додано до колекції.");
        }

        public void RemoveItem(T item)
        {
            if (collection.Remove(item))
            {
                Console.WriteLine($"Елемент {item} видалено з колекції.");
            }
            else
            {
                Console.WriteLine($"Елемент {item} не знайдено в колекції.");
            }
        }

        public void DisplayItems()
        {
            Console.WriteLine("Елементи колекції:");
            foreach (T item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}
