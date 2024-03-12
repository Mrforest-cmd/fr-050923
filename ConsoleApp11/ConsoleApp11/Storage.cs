using System.Collections.Generic;

namespace Storage
{
    public class Tovar
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Tovar(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }
    public class ItemStorage
    {
        private Dictionary<string, Tovar> items = new Dictionary<string, Tovar>();

        public void AddItem(Tovar item)
        {
            if (items.ContainsKey(item.Name))
                items[item.Name].Quantity += item.Quantity;
            else
                items[item.Name] = item;
        }
        public Tovar GetItem(string name)
        {
            if (items.ContainsKey(name))
                return items[name];
            else
                return null;
        }
    }
}