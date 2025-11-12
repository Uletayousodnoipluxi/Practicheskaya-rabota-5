using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace AuthenticationModule
{
    class Program
    {
        static Dictionary<string, string> users = new Dictionary<string, string>();

        // Метод регистрации нового пользователя
        public static void RegisterUser()
        {
            Console.Write("Введите ваше имя пользователя: ");
            var username = Console.ReadLine();

            if (users.ContainsKey(username))
            {
                Console.WriteLine($"Пользователь {username} уже существует.");
                return;
            }

            Console.Write("Введите пароль: ");
            var password = GetPasswordHash(Console.ReadLine());

            users.Add(username, password);
            Console.WriteLine("Вы успешно зарегистрированы!");
        }

        // Метод авторизации пользователя
        public static bool Login(string username, string password)
        {
            if (!users.TryGetValue(username, out var hashedPassword))
            {
                Console.WriteLine("Неправильное имя пользователя");
                return false;
            }

            if (hashedPassword != GetPasswordHash(password))
            {
                Console.WriteLine("Неверный пароль");
                return false;
            }

            Console.WriteLine("Авторизация успешна!");
            return true;
        }

        // Логаута достаточно простой функцией вывода уведомления
        public static void Logout() => Console.WriteLine("Вы вышли из системы.");

        // Хеширование пароля перед сохранением
        private static string GetPasswordHash(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                StringBuilder result = new StringBuilder();
                foreach (byte b in hash)
                    result.Append(b.ToString("X2"));
                return result.ToString();
            }
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Регистрация");
                Console.WriteLine("2. Авторизация");
                Console.WriteLine("3. Выход");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        RegisterUser();
                        break;
                    case 2:
                        Console.Write("Имя пользователя: ");
                        string loginUsername = Console.ReadLine();
                        Console.Write("Пароль: ");
                        string loginPassword = Console.ReadLine();

                        Login(loginUsername, loginPassword);
                        break;
                    case 3:
                        Logout(); // Завершаем работу программы простым выходом из цикла
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Ошибка выбора пункта меню");
                        break;
                }
            }
        }
    }
}
