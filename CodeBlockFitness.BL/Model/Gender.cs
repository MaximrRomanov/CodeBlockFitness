using System;


namespace CodeBlockFitness.BL.Model
{
    [Serializable]
    /// <summary>
    /// Gender.
    /// </summary>
    public class Gender
    { 
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Gender construct.
        /// </summary>
        /// <param name="name">Gender name</param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть равно null или пустым", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
