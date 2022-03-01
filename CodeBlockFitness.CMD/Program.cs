using CodeBlockFitness.BL.Controller;
using System;

namespace CodeBlockFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в приложение Fitness!");
            Console.WriteLine("Введите имя пользователя: ");
            var name = Console.ReadLine();
            var userController = new UserController(name);
            if (userController.IsNewUser)
            {
                Console.WriteLine("Введите пол: ");
                var gender = Console.ReadLine();
                DateTime birthDate = ParseDateTime();
                var weight = ParseDouble("Вес ");
                var height = ParseDouble("Рост ");
 
                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();
          
        }
        /// <summary>
        /// Parse to DateTime method.
        /// </summary>
        /// <returns></returns>
        private static DateTime ParseDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine("Введите дату  DD.MM.YYYY: ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный формат даты рождения!");
                }
            }

            return birthDate;
        }
        /// <summary>
        /// Parse to  Double  method.
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Value.</returns>
        private static double  ParseDouble(string name)
        {
            //TODO: почему вайл не зацикливается
            while (true)
            {
                Console.WriteLine($"Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Неверный формат {name}a!");
                }
            }

        }
    }
}
