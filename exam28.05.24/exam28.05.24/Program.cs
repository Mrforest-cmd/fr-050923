using System;
using System.Collections.Generic;

public interface IObserver
{
    void Update(Article article);
}

public class Blog
{
    private List<IObserver> observers = new List<IObserver>();

    public void Subscribe(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Unsubscribe(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void Notify(Article article)
    {
        foreach (var observer in observers)
        {
            observer.Update(article);
        }
    }

    public void PublishArticle(Article article)
    {
        Console.WriteLine("Publishing article: " + article.Title);
        Notify(article);
    }
}

public class ArticleMemento
{
    public string Title { get; private set; }
    public string Content { get; private set; }

    public ArticleMemento(string title, string content)
    {
        Title = title;
        Content = content;
    }
}

public class Article
{
    public string Title { get; set; }
    public string Content { get; set; }
    private IArticleState state;

    public Article(string title, string content)
    {
        Title = title;
        Content = content;
        state = new DraftState(this);
    }

    public void SetState(IArticleState state)
    {
        this.state = state;
    }

    public void Render()
    {
        state.Render();
    }

    public ArticleMemento SaveState()
    {
        return new ArticleMemento(Title, Content);
    }

    public void RestoreState(ArticleMemento memento)
    {
        Title = memento.Title;
        Content = memento.Content;
    }
}

public interface IArticleState
{
    void Render();
}

public class DraftState : IArticleState
{
    private Article article;

    public DraftState(Article article)
    {
        this.article = article;
    }

    public void Render()
    {
        Console.WriteLine("Article is in Draft state.");
    }
}

public class ReviewState : IArticleState
{
    private Article article;

    public ReviewState(Article article)
    {
        this.article = article;
    }

    public void Render()
    {
        Console.WriteLine("Article is in Review state.");
    }
}

public class PublishedState : IArticleState
{
    private Article article;

    public PublishedState(Article article)
    {
        this.article = article;
    }

    public void Render()
    {
        Console.WriteLine("Article is Published.");
    }
}

public class Subscriber : IObserver
{
    private string name;

    public Subscriber(string name)
    {
        this.name = name;
    }

    public void Update(Article article)
    {
        Console.WriteLine($"{name} has been notified about a new article: {article.Title}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Blog blog = new Blog();

        Subscriber subscriber1 = new Subscriber("Subscriber 1");
        Subscriber subscriber2 = new Subscriber("Subscriber 2");

        blog.Subscribe(subscriber1);
        blog.Subscribe(subscriber2);

        Article article = new Article("My First Article", "This is the content of my first article.");

        article.Render();

        blog.PublishArticle(article);

        article.SetState(new ReviewState(article));
        article.Render();

        var savedState = article.SaveState();

        article.Title = "Modified Title";
        article.Content = "Modified Content";

        article.SetState(new PublishedState(article));
        article.Render();

        article.RestoreState(savedState);
        article.Render();

        blog.PublishArticle(article);
    }
}
