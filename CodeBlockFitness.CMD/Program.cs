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
                Console.WriteLine();
                 var gender =  Console.ReadLine();
            }
            Console.WriteLine(userController.CurrentUser);
           
            // TODO: доделать ввод и обработку остальных данных 
        }
    }
}
