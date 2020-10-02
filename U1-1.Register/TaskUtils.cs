using System;
using System.Collections.Generic;
using System.Text;

namespace U1_1.Register
{
    class TaskUtils
    {
        /// <summary>
        /// Method checks if any people were invited
        /// </summary>

        public static int CheckIfAnyInvited(List<Person> People)
        {
            int HowMany = 0;
            foreach (Person person in People)
            {
                if (person.Invited.Equals(true))
                {
                    HowMany++;
                }
            }
            return HowMany;
        }

        /// <summary>
        /// Method finds the oldest person(or people if they are of the same age)
        /// </summary>
        public static List<Person> FindOldestPerson(List<Person> People)
        {
            DateTime date = People[0].BirthDate;
            for (int i = 1; i < People.Count; i++)
            {
                if (DateTime.Compare(date, People[i].BirthDate) > 0)
                {
                    date = People[i].BirthDate;
                }
            }
            List<Person> person = MakeListOfOldestPeople(date, People);
            return person;
        }
        /// <summary>
        /// Method makes a list of the oldest candidates
        /// </summary>
        /// <param name="date"></param>
        /// <param name="People"></param>
        /// <returns></returns>
        public static List<Person> MakeListOfOldestPeople(DateTime date, List<Person> People)
        {
            List<Person> person = new List<Person>();
            for (int i = 1; i < People.Count; i++)
            {
                if (DateTime.Compare(date, People[i].BirthDate) == 0)
                {
                    Person oldest = People[i];
                    person.Add(oldest);
                }
            }
            return person;
        }
        /// <summary>
        /// Method checks if any attackers were invited
        /// </summary>
        /// <param name="People"></param>
        /// <returns></returns>
        public static int CheckIfAnyAttackersInvited(List<Person> People)
        {
            int HowMany = 0;
            foreach (Person person in People)
            {
                if (person.Position.Equals("Puolėjas"))
                {
                    HowMany++;
                }
            }
            return HowMany;
        }
        /// <summary>
        /// Method finds candidates with the position "Puolėjas"
        /// </summary>
        public static List<Person> FindAttackers(List<Person> People)
        {
            List<Person> attackers = new List<Person>();
            string position = "Puolėjas";
            foreach (Person person in People)
            {
                if (person.Position.Equals(position))
                {
                    attackers.Add(person);
                }
            }
            return attackers;
        }
        /// <summary>
        /// Method finds candidates that were invited
        /// </summary>
        public static List<Person> FindInvitedPeople(List<Person> People)
        {
            List<Person> invited = new List<Person>();
            foreach (Person person in People)
            {
                if (person.Invited.Equals(true))
                {
                    invited.Add(person);
                }
            }
            return invited;
        }
    }
}
