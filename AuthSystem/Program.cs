using AuthSystem.Data;
using AuthSystem.Models;
using System.Globalization;
using System;
using System.Linq;
class Program{
    static void Main()
    {
        using(var db = new AppDbContext())
        {
              
            db.Database.EnsureCreated();
            Console.WriteLine("База даних готова!");
            Console.ReadKey();
        }
        while (true)
        {
            Console.WriteLine("=== Система авторизації ===");
            Console.WriteLine("1.Увійти");
            Console.WriteLine("2.Зареєструватися");
            Console.WriteLine("3. Вийти з програми");
            Console.WriteLine("\r\nВиберіть дію (1-3):");

            string choice = Console.ReadLine();
            if (choice == "1")
            {
                Login();
            }
            else if (choice == "2")
            {
                Register();
            }
            else if (choice == "3") 
            {
                Environment.Exit(0);
            }
        }
       
    }
    static void Register()
    {
        Console.Clear();
        Console.WriteLine("Логін");
        string userName = Console.ReadLine();

        Console.WriteLine("Пароль");
        string password = Console.ReadLine();

        Console.WriteLine("Повтор пароля");
        string password2 = Console.ReadLine();

        if (userName.Length == 0 ||  password != password2 || password.Length < 6 || !password.Any(char.IsDigit))
        {
            Console.WriteLine("Перевірте вимоги");
            return;
        }
        var newUser = new User
        {
            ID = Guid.NewGuid().ToString(),
            UserName = userName,
            PasswordHash = password,
            CreatedAt = DateTime.Now
        };
        using (var db = new AppDbContext()) {

            bool exicts = db.Users.Any(u => u.UserName == userName);
            if (exicts) {
                Console.WriteLine("Логін вже існує");
                return;
            }

            db.Users.Add(newUser);
            db.SaveChanges();
       
        }

        Console.WriteLine("Реєстрація успішна!");
        Console.ReadKey();
        

    }
    static void Login()
    {
        Console.WriteLine("Введіть логін ");
        string userName = Console.ReadLine();
        Console.WriteLine("Введіть пароль");
        string password = Console.ReadLine();
        using (var db = new AppDbContext())
        {
            var user = db.Users.FirstOrDefault(u => u.UserName == userName);

            if (user == null)
            {

                Console.WriteLine("Користувача не знайдено");
                return;
            }
            if (user.PasswordHash != password)
            {
                Console.WriteLine("Пароль не вріний");
                return;
            }

            Console.WriteLine("Вхід успішний");
        }
    }
}

