using System;
using System.Collections.Generic;
using System.Text;

namespace U1_1.Register
{
    /// <summary>
    ///class defining list (Person) variables
    /// </summary>
    class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public int Height { get; set; }
        public string Position { get; set; }
        public string Club { get; set; }
        public bool Invited { get; set; }
        public bool Captain { get; set; }

        public Person(string name, string surname, DateTime birthdate, int height, 
            string position, string club, bool invited, bool captain)
        {
            this.Name = name;
            this.Surname = surname;
            this.BirthDate = birthdate;
            this.Height = height;
            this.Position = position;
            this.Club = club;
            this.Invited = invited;
            this.Captain = captain;
        }
        /// <summary></summary>
        /// Method calculates the age of the candidate
        /// </summary>
        public int CalculateAge()
        {
            DateTime Today = DateTime.Today;
            int age = Today.Year - this.BirthDate.Year;
            if (this.BirthDate.Date > Today.AddYears(-age))
            {
                age--;
            }
            return age;
        }
    }
}
