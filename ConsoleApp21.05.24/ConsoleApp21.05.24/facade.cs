using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp21._05._24
{
    // Клас для представлення новини
    public class News
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Category { get; set; }
    }

    // Фасад для керування підпискою та відправлення сповіщень
    public class NewsSubscriptionFacade
    {
        private Dictionary<string, List<ISubscriber>> subscriptions = new Dictionary<string, List<ISubscriber>>();
        private List<News> newsList = new List<News>();

        public void Subscribe(string category, ISubscriber subscriber)
        {
            if (!subscriptions.ContainsKey(category))
                subscriptions[category] = new List<ISubscriber>();

            subscriptions[category].Add(subscriber);
        }

        public void Unsubscribe(string category, ISubscriber subscriber)
        {
            if (subscriptions.ContainsKey(category))
                subscriptions[category].Remove(subscriber);
        }

        public void PublishNews(News news)
        {
            newsList.Add(news);

            if (subscriptions.ContainsKey(news.Category))
            {
                foreach (var subscriber in subscriptions[news.Category])
                {
                    subscriber.Notify(news);
                }
            }
        }
    }

    // Інтерфейс для підписників
    public interface ISubscriber
    {
        void Notify(News news);
    }

    // Клас, що реалізує інтерфейс підписника
    public class Subscriber : ISubscriber
    {
        public void Notify(News news)
        {
            Console.WriteLine($"Received notification: {news.Title} - {news.Content}");
        }
    }
}
