using CodeBlockFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;



namespace CodeBlockFitness.BL.Controller
{
    /// <summary>
    /// User controller.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// User of application.
        /// </summary>
        public List<User> Users { get; }
        public User CurrentUser { get; }
        public bool IsNewUser { get; } = false;

        /// <summary>
        /// First constructor.
        /// </summary>
        /// <param name="name"></param>
        public UserController(string userName )
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(userName));
            }
            Users = GetUsersData();
            // LINQ
            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);
            if(CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }

        }

        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height= 1)
        {
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }
        /// <summary>
        /// Get saved list og users.
        /// </summary>
        private List<User> GetUsersData()
        {   

            var formatter = new BinaryFormatter(); // creating 
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
               if( formatter.Deserialize(fs) is List<User> user)
                {
                   return user;
                }
                else
                {
                    return new List<User>();
                }
            }  
        }

        /// <summary>
        /// Save data in the file users.dat and serializable.
        /// </summary>
        public void Save()
        {
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(fs, Users);
            }
        } 
    }
}
