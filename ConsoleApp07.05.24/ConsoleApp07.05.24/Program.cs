using System;
using System.Collections.Generic;

// Singleton для доступу до меню
public sealed class Menu
{
    private static readonly Menu instance = new Menu();
    public List<MenuItem> Items { get; private set; }

    private Menu()
    {
        Items = new List<MenuItem>();
    }

    public static Menu Instance
    {
        get
        {
            return instance;
        }
    }

    public void AddItem(MenuItem item)
    {
        Items.Add(item);
    }

    public void RemoveItem(MenuItem item)
    {
        Items.Remove(item);
    }
}

// Клас, що представляє страву в меню
public class MenuItem
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }

    public MenuItem(string name, decimal price, string description)
    {
        Name = name;
        Price = price;
        Description = description;
    }
}

// Декоратор для додавання інгредієнтів до страв
public abstract class IngredientDecorator : MenuItem
{
    protected MenuItem menuItem;

    public IngredientDecorator(MenuItem item) : base(item.Name, item.Price, item.Description)
    {
        menuItem = item;
    }
}

// Конкретний декоратор для додавання сиру
public class CheeseDecorator : IngredientDecorator
{
    public CheeseDecorator(MenuItem item) : base(item)
    {
        Name = $"{item.Name} з сиром";
        Price = item.Price + 1.99m;
    }
}

// Конкретний декоратор для додавання перцю
public class PepperDecorator : IngredientDecorator
{
    public PepperDecorator(MenuItem item) : base(item)
    {
        Name = $"{item.Name} з перцем";
        Price = item.Price + 0.99m;
    }
}

// Клас для замовлення
public class Order
{
    public List<MenuItem> Items { get; private set; }
    public OrderStatus Status { get; set; }

    public Order()
    {
        Items = new List<MenuItem>();
        Status = OrderStatus.Pending;
    }

    public void AddItem(MenuItem item)
    {
        Items.Add(item);
        Console.WriteLine($"Додано до замовлення: {item.Name} - {item.Price:C}");
    }

    public void RemoveItem(MenuItem item)
    {
        Items.Remove(item);
        Console.WriteLine($"Видалено із замовлення: {item.Name}");
    }

    public void AddIngredient(IngredientDecorator ingredient, MenuItem item)
    {
        Items.Remove(item);
        Items.Add(ingredient);
        Console.WriteLine($"Додано інгредієнт до: {ingredient.Name} - {ingredient.Price:C}");
    }
}

// Перечислення статусів замовлення
public enum OrderStatus
{
    Pending,
    Preparing,
    Ready,
    Delivering,
    Completed
}

// Клас для створення замовлення на винос
public class TakeawayOrder : Order
{
    public void Pickup()
    {
        Console.WriteLine("Замовлення готове до отримання!");
    }
}

// Клас для створення замовлення з доставкою
public class DeliveryOrder : Order
{
    public void Deliver()
    {
        Console.WriteLine("Замовлення доставляється!");
    }
}

// Фабричний метод для створення різних типів замовлень
public abstract class OrderFactory
{
    public abstract Order CreateOrder();
}

public class TakeawayOrderFactory : OrderFactory
{
    public override Order CreateOrder()
    {
        return new TakeawayOrder();
    }
}

public class DeliveryOrderFactory : OrderFactory
{
    public override Order CreateOrder()
    {
        return new DeliveryOrder();
    }
}

// Клас сповіщення клієнта про зміну статусу замовлення
public class OrderStatusObserver
{
    public void Update(Order order, OrderStatus newStatus)
    {
        order.Status = newStatus;
        Console.WriteLine($"Статус замовлення змінено на: {newStatus}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Приклад використання
        Menu.Instance.AddItem(new MenuItem("Піца", 10.99m, "Дуже смачна піца"));
        Menu.Instance.AddItem(new MenuItem("Салат", 5.99m, "Свіжий салат з овочів"));

        OrderFactory factory = new TakeawayOrderFactory();
        Order order = factory.CreateOrder();

        order.AddItem(Menu.Instance.Items[0]);
        order.AddItem(Menu.Instance.Items[1]);

        // Додавання інгредієнтів до страви
        order.AddIngredient(new CheeseDecorator(Menu.Instance.Items[0]), Menu.Instance.Items[0]);
        order.AddIngredient(new PepperDecorator(Menu.Instance.Items[0]), Menu.Instance.Items[0]);

        // Оновлення статусу замовлення
        OrderStatusObserver observer = new OrderStatusObserver();
        observer.Update(order, OrderStatus.Preparing);
        observer.Update(order, OrderStatus.Ready);

        // Виклик методу для замовлення на винос
        ((TakeawayOrder)order).Pickup();

        Console.ReadLine();
    }
}