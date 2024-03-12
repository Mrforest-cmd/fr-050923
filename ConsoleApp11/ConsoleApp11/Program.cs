using Kassa;
using Requests;
using Storage;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp11
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            ItemStorage storage = new ItemStorage();
            storage.AddItem(new Tovar("Хліб 300 г", 43, 100));
            storage.AddItem(new Tovar("Молоко 1 л", 73, 50));
            storage.AddItem(new Tovar("Яблуко", 30, 200));

            RequestsHandler requestsHandler = new RequestsHandler(storage);
            CashRegister cashRegister = new CashRegister(requestsHandler, 1);

            List<Tovar> items = new List<Tovar>
        {
            new Tovar("Хліб 300 г", 43, 2),
            new Tovar("Молоко 1 л", 73, 3),
            new Tovar("Яблуко", 30, 5)
        };

            double availableMoney = 450;
            cashRegister.CheckoutItems(items, availableMoney);
        }
    }
}
