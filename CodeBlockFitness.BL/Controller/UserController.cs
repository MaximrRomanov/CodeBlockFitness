using CodeBlockFitness.BL.Model;
using System;
using System.IO;
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
        public User User { get; }

        /// <summary>
        /// First constructor.
        /// </summary>
        /// <param name="name"></param>
        public UserController(string userName, string genderName, DateTime birthDate, double weight, double height )
        {
            //TODO: Проверки 
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDate, weight, height);
        }

        /// <summary>
        /// Second constructor.
        /// </summary>
        public UserController()
        {   // Load data from the file and deseriakizable.

            var formatter = new BinaryFormatter(); // creating 
            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
               if( formatter.Deserialize(fs) is User user)
                {
                    User = user;
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
                formatter.Serialize(fs, User);
            }
        } 
    }
}
