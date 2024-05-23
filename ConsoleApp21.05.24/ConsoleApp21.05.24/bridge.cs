using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp21._05._24
{
    // Абстрактний клас для представлення новини
    public abstract class News
    {
        protected INotificationSender notificationSender;

        public News(INotificationSender sender)
        {
            notificationSender = sender;
        }

        public abstract void Publish(string title, string content, string category);
    }

    // Конкретні реалізації новин для різних категорій
    public class SportsNews : News
    {
        public SportsNews(INotificationSender sender) : base(sender) { }

        public override void Publish(string title, string content, string category)
        {
            notificationSender.SendNotification($"New sports news: {title} - {content}", category);
        }
    }

    public class PoliticsNews : News
    {
        public PoliticsNews(INotificationSender sender) : base(sender) { }

        public override void Publish(string title, string content, string category)
        {
            notificationSender.SendNotification($"New politics news: {title} - {content}", category);
        }
    }

    // Інтерфейс для відправлення сповіщень
    public interface INotificationSender
    {
        void SendNotification(string message, string category);
    }

    // Конкретна реалізація відправлення сповіщень
    public class EmailNotificationSender : INotificationSender
    {
        private Dictionary<string, List<string>> subscriptions = new Dictionary<string, List<string>>();

        public void Subscribe(string category, string email)
        {
            if (!subscriptions.ContainsKey(category))
                subscriptions[category] = new List<string>();

            subscriptions[category].Add(email);
        }

        public void Unsubscribe(string category, string email)
        {
            if (subscriptions.ContainsKey(category))
                subscriptions[category].Remove(email);
        }

        public void SendNotification(string message, string category)
        {
            if (subscriptions.ContainsKey(category))
            {
                foreach (var email in subscriptions[category])
                {
                    Console.WriteLine($"Sending notification to {email}: {message}");
                }
            }
        }
    }
}
