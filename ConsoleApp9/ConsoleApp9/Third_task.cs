using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Third_task
{
    using System;
    using System.Collections.Generic;

    namespace Third_task
    {
        public class User
        {
            public string UserName { get; }
            public string Password { get; }

            public bool isauth {  get; set; }

            public User(string userName, string password)
            {
                UserName = userName;
                Password = password;
            }
        }

        public class AuthorizationSystem
        {
            List<User> users = new List<User>();

            public void AddUser(User user)
            {
                users.Add(user);
            }

            public void RemoveUser(User user)
            {
                users.Remove(user);
            }

            public void ShowUsers()
            {
                foreach (User user in users)
                {
                    Console.WriteLine($"Username: {user.UserName}\nPassword: {user.Password}\nIs Authorized: {user.isauth}");
                }
            }

            public event EventHandler UserAuthorized;

            protected virtual void OnUserAuthorized(User user)
            {
                UserAuthorized?.Invoke(user, EventArgs.Empty);
            }

            public void AuthorizeUser(User user, string inputPassword)
            {
                if (user.Password == inputPassword)
                {
                    user.isauth = true;
                    OnUserAuthorized(user);
                }
                else
                {
                    Console.WriteLine($"Incorrect password for user: {user.UserName}");
                }
            }

            public void BlockUser(User user)
            {
                user.isauth = false;
                Console.WriteLine($"User {user.UserName} has been blocked.");
            }
        }

        delegate void AuthorizationHandler(User user);

        class Program
        {
            static void Main3(string[] args)
            {
                AuthorizationSystem authSystem = new AuthorizationSystem();

                User user1 = new User("user1", "password1");
                User user2 = new User("user2", "password2");

                authSystem.AddUser(user1);
                authSystem.AddUser(user2);

                authSystem.UserAuthorized += (sender, arg) =>
                {
                    User user = (User)sender;
                    Console.WriteLine($"User {user.UserName} has been authorized.");
                };

                authSystem.ShowUsers();

                Console.WriteLine("Enter password for user1:");
                string passwordInput = Console.ReadLine();
                authSystem.AuthorizeUser(user1, passwordInput);

                authSystem.ShowUsers();

                authSystem.BlockUser(user2);

                authSystem.ShowUsers();
            }
        }
    }


}
/*
Створіть консольну програму, яка моделює систему авторизації користувачів і використовує делегаті та події для сповіщення про стан авторизації.

Вимоги:

Створення структури даних:
Створіть клас User з полями для імені користувача, паролю та статусу авторизації.
Створіть клас AuthorizationSystem, який буде містити список користувачів та базові операції з ними (додавання, видалення, виведення на екран).

Створення делегатів:
Створіть делегат AuthorizationHandler, який приймає об'єкт класу User.
Створіть два методи, що відповідають сигнатурі делегата: один для виведення повідомлення про стан авторизації користувача,
інший - для блокування користувача при помилковій спробі авторизації.

Обробка подій:
В класі AuthorizationSystem створіть подію UserAuthorized, яка буде викликатися при успішній авторизації користувача.
Додайте метод OnUserAuthorized, який буде викликати подію UserAuthorized та передавати в неї авторизованого користувача.

Використання делегатів:
Створіть об'єкт класу AuthorizationSystem.
Створіть делегат та підпишіть його на метод виведення повідомлення про стан авторизації користувача.
Додайте кілька користувачів до системи та спробуйте викликати подію при їхній авторизації.

Додаткова функціональність:
Реалізуйте можливість видалення користувачів з системи та виклику відповідних подій.
Додайте можливість блокування користувачів та виклику подій при такій дії.

Критерії успішності:
Програма повинна коректно обробляти введені дані та виводити повідомлення про події.
Використання делегатів для виклику методів обробки подій.
Чітко визначені операції зі списком користувачів та їх реалізація.
 */