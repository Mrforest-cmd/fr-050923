using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Linq;
using Newtonsoft.Json;

// Клас Персонаж
class Character
{
    public string Name { get; set; }
    public int Level { get; set; }
    public int Health { get; set; }
    public int Strength { get; set; }
    public int Dexterity { get; set; }
    public int Intelligence { get; set; }
    public List<Item> Inventory { get; set; }

    public Character(string name, int level, int health, int strength, int dexterity, int intelligence)
    {
        Name = name;
        Level = level;
        Health = health;
        Strength = strength;
        Dexterity = dexterity;
        Intelligence = intelligence;
        Inventory = new List<Item>();
    }
}

// Клас Предмет
public class Item
{
    public string Name { get; set; }
    public string Type { get; set; }
    public int Value { get; set; }
    public int Weight { get; set; }

    public Item(string name, string type, int value, int weight)
    {
        Name = name;
        Type = type;
        Value = value;
        Weight = weight;
    }
}

// Клас Гра
class Game
{
    public List<Character> characters;
    public List<Item> items;

    public Game()
    {
        characters = new List<Character>();
        items = new List<Item>();
    }

    public void AddCharacter(Character character)
    {
        characters.Add(character);
    }

    public void RemoveCharacter(Character character)
    {
        characters.Remove(character);
    }

    public void AddItem(Item item)
    {
        items.Add(item);
    }

    public void AddItemToInventory(Character character, Item item)
    {
        character.Inventory.Add(item);
    }

    public void RemoveItemFromInventory(Character character, Item item)
    {
        character.Inventory.Remove(item);
    }

    public Character FindCharacterByName(string name)
    {
        return characters.Find(c => c.Name == name);
    }

    public void SaveToFile(string filePath)
    {
        var gameData = new
        {
            Characters = characters,
            Items = items
        };

        File.WriteAllText(filePath, JsonConvert.SerializeObject(gameData, Formatting.Indented));
    }
}

// Головний клас з консольним інтерфейсом
class Program
{
    

    static Game game = new Game();

    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Виберіть опцію:");
            Console.WriteLine("1. Створити персонажа");
            Console.WriteLine("2. Видалити персонажа");
            Console.WriteLine("3. Додати предмет");
            Console.WriteLine("4. Додати предмет до інвентаря персонажа");
            Console.WriteLine("5. Видалити предмет з інвентаря персонажа");
            Console.WriteLine("6. Змінити характеристики персонажа");
            Console.WriteLine("7. Відобразити інвентар персонажа");
            Console.WriteLine("8. Знайти персонажа за ім'ям");
            Console.WriteLine("9. Зберегти дані в файл");
            Console.WriteLine("0. Вийти");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateCharacter();
                    break;
                case "2":
                    RemoveCharacter();
                    break;
                case "3":
                    CreateItem();
                    break;
                case "4":
                    AddItemToCharacterInventory();
                    break;
                case "5":
                    RemoveItemFromCharacterInventory();
                    break;
                case "6":
                    UpdateCharacterStats();
                    break;
                case "7":
                    DisplayCharacterInventory();
                    break;
                case "8":
                    FindCharacterByName();
                    break;
                case "9":
                    SaveToFile();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void CreateCharacter()
    {
        Console.Write("Введіть ім'я персонажа: ");
        string name = Console.ReadLine();

        Console.Write("Введіть рівень персонажа: ");
        int level = int.Parse(Console.ReadLine());

        Console.Write("Введіть здоров'я персонажа: ");
        int health = int.Parse(Console.ReadLine());

        Console.Write("Введіть силу персонажа: ");
        int strength = int.Parse(Console.ReadLine());

        Console.Write("Введіть спритність персонажа: ");
        int dexterity = int.Parse(Console.ReadLine());

        Console.Write("Введіть інтелект персонажа: ");
        int intelligence = int.Parse(Console.ReadLine());

        Character character = new Character(name, level, health, strength, dexterity, intelligence);
        game.AddCharacter(character);

        Console.WriteLine("Персонаж створений.");
    }

    static void RemoveCharacter()
    {
        Console.Write("Введіть ім'я персонажа для видалення: ");
        string name = Console.ReadLine();

        Character character = game.FindCharacterByName(name);

        if (character == null)
        {
            Console.WriteLine("Персонаж не знайдений.");
            return;
        }

        game.RemoveCharacter(character);
        Console.WriteLine("Персонаж видалений.");
    }

    static void CreateItem()
    {
        Console.Write("Введіть назву предмета: ");
        string name = Console.ReadLine();

        Console.Write("Введіть тип предмета (зброя, броня, зілля тощо): ");
        string type = Console.ReadLine();

        Console.Write("Введіть вартість предмета: ");
        int value = int.Parse(Console.ReadLine());

        Console.Write("Введіть вагу предмета: ");
        int weight = int.Parse(Console.ReadLine());

        Item item = new Item(name, type, value, weight);
        game.AddItem(item);

        Console.WriteLine("Предмет створений.");
    }

    static void AddItemToCharacterInventory()
    {
        Console.Write("Введіть ім'я персонажа: ");
        string name = Console.ReadLine();

        Character character = game.FindCharacterByName(name);

        if (character == null)
        {
            Console.WriteLine("Персонаж не знайдений.");
            return;
        }

        Console.Write("Введіть назву предмета для додавання: ");
        string itemName = Console.ReadLine();

        Item item = game.items.Find(i => i.Name == itemName);

        if (item == null)
        {
            Console.WriteLine("Предмет не знайдений.");
            return;
        }

        game.AddItemToInventory(character, item);
        Console.WriteLine("Предмет доданий до інвентаря персонажа.");
    }

    static void RemoveItemFromCharacterInventory()
    {
        Console.Write("Введіть ім'я персонажа: ");
        string name = Console.ReadLine();
        Character character = game.FindCharacterByName(name);

        if (character == null)
        {
            Console.WriteLine("Персонаж не знайдений.");
            return;
        }

        Console.Write("Введіть назву предмета для видалення: ");
        string itemName = Console.ReadLine();

        Item item = character.Inventory.Find(i => i.Name == itemName);

        if (item == null)
        {
            Console.WriteLine("Предмет не знайдений в інвентарі персонажа.");
            return;
        }

        game.RemoveItemFromInventory(character, item);
        Console.WriteLine("Предмет видалений з інвентаря персонажа.");
    }

    static void UpdateCharacterStats()
    {
        Console.Write("Введіть ім'я персонажа: ");
        string name = Console.ReadLine();

        Character character = game.FindCharacterByName(name);

        if (character == null)
        {
            Console.WriteLine("Персонаж не знайдений.");
            return;
        }

        Console.Write("Введіть новий рівень персонажа: ");
        character.Level = int.Parse(Console.ReadLine());

        Console.Write("Введіть нове здоров'я персонажа: ");
        character.Health = int.Parse(Console.ReadLine());

        Console.Write("Введіть нову силу персонажа: ");
        character.Strength = int.Parse(Console.ReadLine());

        Console.Write("Введіть нову спритність персонажа: ");
        character.Dexterity = int.Parse(Console.ReadLine());

        Console.Write("Введіть новий інтелект персонажа: ");
        character.Intelligence = int.Parse(Console.ReadLine());

        Console.WriteLine("Характеристики персонажа оновлені.");
    }

    static void DisplayCharacterInventory()
    {
        Console.Write("Введіть ім'я персонажа: ");
        string name = Console.ReadLine();

        Character character = game.FindCharacterByName(name);

        if (character == null)
        {
            Console.WriteLine("Персонаж не знайдений.");
            return;
        }

        Console.WriteLine($"Інвентар персонажа {character.Name}:");

        if (character.Inventory.Count == 0)
        {
            Console.WriteLine("Інвентар порожній.");
        }
        else
        {
            foreach (Item item in character.Inventory)
            {
                Console.WriteLine($"Назва: {item.Name}, Тип: {item.Type}, Вартість: {item.Value}, Вага: {item.Weight}");
            }
        }
    }

    static void FindCharacterByName()
    {
        Console.Write("Введіть ім'я персонажа: ");
        string name = Console.ReadLine();

        Character character = game.FindCharacterByName(name);

        if (character == null)
        {
            Console.WriteLine("Персонаж не знайдений.");
        }
        else
        {
            Console.WriteLine($"Персонаж знайдений: {character.Name}, Рівень: {character.Level}, Здоров'я: {character.Health}, Сила: {character.Strength}, Спритність: {character.Dexterity}, Інтелект: {character.Intelligence}");
        }
    }

    static void SaveToFile()
    {
        Console.Write("Введіть шлях до файлу для збереження: ");
        string filePath = Console.ReadLine();

        game.SaveToFile(filePath);
        Console.WriteLine("Дані збережені в файл.");
    }
}