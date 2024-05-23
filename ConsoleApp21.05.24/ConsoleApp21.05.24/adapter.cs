using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp21._05._24
{
    // Існуючий клас для відправлення сповіщень
    public class LegacyNotificationSender
    {
        public void SendNotification(string message)
        {
            Console.WriteLine($"Sending notification: {message}");
        }
    }

    // Інтерфейс для відправлення сповіщень з категорією
    public interface ICategorizedNotificationSender
    {
        void SendNotification(string message, string category);
    }

    // Адаптер для існуючого класу відправлення сповіщень
    public class NotificationSenderAdapter : ICategorizedNotificationSender
    {
        private LegacyNotificationSender legacySender;

        public NotificationSenderAdapter(LegacyNotificationSender sender)
        {
            legacySender = sender;
        }

        public void SendNotification(string message, string category)
        {
            legacySender.SendNotification($"[{category}] {message}");
        }
    }

    // Клас для керування підпискою та відправлення сповіщень
    public class NewsSubscriptionManager
    {
        private Dictionary<string, List<string>> subscriptions = new Dictionary<string, List<string>>();
        private ICategorizedNotificationSender notificationSender;

        public NewsSubscriptionManager(ICategorizedNotificationSender sender)
        {
            notificationSender = sender;
        }

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

        public void PublishNews(string title, string content, string category)
        {
            var message = $"New news: {title} - {content}";

            if (subscriptions.ContainsKey(category))
            {
                foreach (var email in subscriptions[category])
                {
                    notificationSender.SendNotification(message, category);
                }
            }
        }
    }
}
