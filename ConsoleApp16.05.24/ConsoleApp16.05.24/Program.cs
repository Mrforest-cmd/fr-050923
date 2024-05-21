using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using Newtonsoft.Json;

public class Game
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Genre { get; set; }
    public int ReleaseYear { get; set; }
    public string Developer { get; set; }
    public double Rating { get; set; }
}


public class GameController
{
    private static List<Game> games = new List<Game>();
    private static int nextId = 1;

    public static void ListGames()
    {
        View.ShowGamesList(games);
    }

    public static void AddGame()
    {
        Game newGame = View.PromptForGameDetails();
        newGame.Id = nextId++;
        games.Add(newGame);
        View.ShowMessage("Гру успішно додано.");
    }

    public static void EditGame()
    {
        int gameId = View.PromptForGameSelection(games);
        if (gameId != -1)
        {
            Game gameToEdit = games.Find(g => g.Id == gameId);
            Game updatedGame = View.PromptForGameDetails(gameToEdit);
            int index = games.FindIndex(g => g.Id == gameId);
            games[index] = updatedGame;
            View.ShowMessage("Гру успішно відредаговано.");
        }
    }

    public static void DeleteGame()
    {
        int gameId = View.PromptForGameSelection(games);
        if (gameId != -1)
        {
            Game gameToDelete = games.Find(g => g.Id == gameId);
            games.Remove(gameToDelete);
            View.ShowMessage("Гру успішно видалено.");
        }
    }

    public static void ViewGameDetails()
    {
        int gameId = View.PromptForGameSelection(games);
        if (gameId != -1)
        {
            Game selectedGame = games.Find(g => g.Id == gameId);
            View.ShowGameDetails(selectedGame);
        }
    }

    public static void SaveGames(string filePath)
    {
        string json = JsonConvert.SerializeObject(games, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText(filePath, json);
    }

    public static void LoadGames(string filePath)
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            games = JsonConvert.DeserializeObject<List<Game>>(json);
            nextId = games.Count > 0 ? games.Max(g => g.Id) + 1 : 1;
        }
    }
}

public static class View
{
    public static void ShowMainMenu()
    {
        Console.WriteLine("Бібліотека відеоігор");
        Console.WriteLine("1. Переглянути список ігор");
        Console.WriteLine("2. Додати нову гру");
        Console.WriteLine("3. Редагувати гру");
        Console.WriteLine("4. Видалити гру");
        Console.WriteLine("5. Переглянути деталі гри");
        Console.WriteLine("0. Вихід");
        Console.Write("Виберіть дію: ");
    }

    public static void ShowGamesList(List<Game> games)
    {
        Console.WriteLine("Список ігор:");
        foreach (Game game in games)
        {
            Console.WriteLine("{0}. {1} ({2}, {3}, {4}), Рейтинг: {5}", game.Id, game.Title, game.Genre, game.ReleaseYear, game.Developer, game.Rating);
        }
        Console.WriteLine();
    }

    public static Game PromptForGameDetails(Game game = null)
    {
        Console.Write("Назва: ");
        string title = Console.ReadLine();

        Console.Write("Жанр: ");
        string genre = Console.ReadLine();

        Console.Write("Рік випуску: ");
        int releaseYear = int.Parse(Console.ReadLine());

        Console.Write("Розробник: ");
        string developer = Console.ReadLine();

        Console.Write("Рейтинг: ");
        double rating = double.Parse(Console.ReadLine());

        if (game == null)
            return new Game { Title = title, Genre = genre, ReleaseYear = releaseYear, Developer = developer, Rating = rating };
        else
        {
            game.Title = title;
            game.Genre = genre;
            game.ReleaseYear = releaseYear;
            game.Developer = developer;
            game.Rating = rating;
            return game;
        }
    }

    public static int PromptForGameSelection(List<Game> games)
    {
        ShowGamesList(games);
        Console.Write("Виберіть гру (введіть ID або -1 для скасування): ");
        int selectedId = int.Parse(Console.ReadLine());
        if (selectedId == -1 || !games.Exists(g => g.Id == selectedId))
            return -1;
        else
            return selectedId;
    }

    public static void ShowGameDetails(Game game)
    {
        Console.WriteLine("Деталі гри:");
        Console.WriteLine("Назва: {0}", game.Title);
        Console.WriteLine("Жанр: {0}", game.Genre);
        Console.WriteLine("Рік випуску: {0}", game.ReleaseYear);
        Console.WriteLine("Розробник: {0}", game.Developer);
        Console.WriteLine("Рейтинг: {0}", game.Rating);
        Console.WriteLine();
    }

    public static void ShowMessage(string message)
    {
        Console.WriteLine(message);
        Console.WriteLine();
    }
}

class Program
{
    private const string FilePath = "games.json";

    static void Main(string[] args)
    {
        GameController.LoadGames(FilePath);

        while (true)
        {
            View.ShowMainMenu();
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    GameController.ListGames();
                    break;
                case 2:
                    GameController.AddGame();
                    break;
                case 3:
                    GameController.EditGame();
                    break;
                case 4:
                    GameController.DeleteGame();
                    break;
                case 5:
                    GameController.ViewGameDetails();
                    break;
                case 0:
                    GameController.SaveGames(FilePath);
                    return;
                default:
                    View.ShowMessage("Невірний вибір. Спробуйте ще раз.");
                    break;
            }
        }
    }
}