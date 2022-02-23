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
            Console.WriteLine("Введите пол: ");
            var gender = Console.ReadLine();
            Console.WriteLine("Введите дату своего рождения: ");
            var birthDate = DateTime.Parse(Console.ReadLine());
            //birthDate =  DateTime.TryParse(birthDate,result);
            Console.WriteLine("Введите вес: ");
            var weight = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите рост: ");
            var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birthDate, weight, height);
            userController.Save();
        }
    }
}
