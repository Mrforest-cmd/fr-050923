using Requests;
using Storage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Kassa
{
    public class CashRegister
    {
        private RequestsHandler requestsHandler;
        private int registerNumber;

        public CashRegister(RequestsHandler requestsHandler, int registerNumber)
        {
            this.requestsHandler = requestsHandler;
            this.registerNumber = registerNumber;
        }

        public void CheckoutItems(List<Tovar> items, double availableMoney)
        {
            double totalCost = items.Sum(item => item.Price * item.Quantity);

            if (totalCost > availableMoney)
            {
                Console.WriteLine("Недостатньо грошей для оплати всіх товарів.");
                RemoveItemsFromCart(items, availableMoney);
            }
            else
            {
                if (requestsHandler.CheckoutItems(items))
                {
                    PrintReceipt(items);
                }
                else
                {
                    Console.WriteLine("Немає достатньої кількості товарів на складі.");
                }
            }
        }

        private void RemoveItemsFromCart(List<Tovar> items, double availableMoney)
        {
            while (true)
            {
                double totalCost = items.Sum(item => item.Price * item.Quantity);
                if (totalCost <= availableMoney)
                {
                    break;
                }

                Console.WriteLine("Виберіть товар для видалення з кошика (введіть номер):");
                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {items[i].Name} - {items[i].Price} ₴ x {items[i].Quantity}");
                }

                int itemIndex;
                if (int.TryParse(Console.ReadLine(), out itemIndex) && itemIndex > 0 && itemIndex <= items.Count)
                {
                    items.RemoveAt(itemIndex - 1);
                }
                else
                {
                    Console.WriteLine("Неправильний вибір товару.");
                }
            }

            if (requestsHandler.CheckoutItems(items))
            {
                PrintReceipt(items);
            }
            else
            {
                Console.WriteLine("Немає достатньої кількості товарів на складі.");
            }
        }

        private void PrintReceipt(List<Tovar> items)
        {
            Console.WriteLine("=== Чек ===");
            Console.WriteLine($"Каса №{registerNumber}");
            Console.WriteLine($"Дата: {DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss")}");
            Console.WriteLine("----------------------------");

            double total = 0;
            foreach (var item in items)
            {
                double itemTotal = item.Price * item.Quantity;
                total += itemTotal;
                Console.WriteLine($"{item.Name} x {item.Quantity} = {itemTotal} ₴");
            }

            Console.WriteLine("----------------------------");
            Console.WriteLine($"Загальна сума: {total} ₴");
            Console.WriteLine("=============================");
        }
    }

}
