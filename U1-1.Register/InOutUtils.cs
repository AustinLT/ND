using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace U1_1.Register
{
    /// <summary>
    /// Class containing reading and printing methods
    /// </summary>
    static class InOutUtils
    {
        /// <summary>
        /// Method that reads the data from the file
        /// </summary>
        public static List<Person> ReadPeople(string fileName)
        {
            List<Person> People = new List<Person>();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                string name = Values[0];
                string surname = Values[1];
                DateTime birthDate = DateTime.Parse(Values[2]);
                int height = int.Parse(Values[3]);
                string position = Values[4];
                string club = Values[5];
                bool invited = bool.Parse(Values[6]);
                bool captain = bool.Parse(Values[7]);

                Person people = new Person(name, surname, birthDate, height, position, club, invited, captain);
                People.Add(people);
            }
        return People;
        }
        /// <summary>
        /// Method prints all of the candidates to a txt file
        /// </summary>
        public static void PrintAllPeople(string fileName, List<Person> People)
        {           
            string[] lines = new string[People.Count];
            string info;
            info = String.Format("| {0, -9} | {1, -9} | {2, 6} | {3, 5} | {4, -5} | {5, -10} | {6, -9} | {7, -11} ",
           "Vardas", "Pavardė", "Gimimo data", "Ūgis (cm)", "Pozicija", "Klubo pavadinimas", 
           "Ar pakviestas?", "Ar kapitonas ? |" + Environment.NewLine);
            File.WriteAllText(fileName, info + Environment.NewLine, Encoding.UTF8);
            for (int i = 0; i < People.Count; i++)
            {
                lines[i] = String.Format("| {0, -9} | {1, -9} | {2, 6:yyy-MM-dd} | {3, 10} | {4, -8} | {5, -17} | {6, -14} | {7, -13} |",
                People[i].Name, People[i].Surname, People[i].BirthDate, People[i].Height, People[i].Position,
                People[i].Club, People[i].Invited, People[i].Captain);
            }
            File.AppendAllLines(fileName, lines, Encoding.UTF8);
        }
        /// <summary>
        /// Method that prints the oldest candidate(or candidates if they are of the same age)
        /// </summary>
        public static void PrintOldestCandidates(List<Person> OldestCandidates)
        {
            Console.WriteLine("| {0, -10} | {1, -10} | {2, 10} |", "Vardas", "Pavardė", "Amžius", Encoding.UTF8);
            Console.WriteLine(new string('-', 40));
            foreach (Person person in OldestCandidates)
            {
                Console.WriteLine("| {0, -10} | {1, -10} | {2, 7} m. |", person.Name, person.Surname, person.CalculateAge(), Encoding.UTF8);
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Method that prints players that are in the position of attacker
        /// </summary>
        public static void PrintAttackers(List<Person> Attackers)
        {
            Console.WriteLine("| {0, -9} | {1, -10} | {2, 2} |", "Vardas", "Pavardė", "Ūgis (cm)", Encoding.UTF8);
            Console.WriteLine(new string('-', 38));
            foreach (Person person in Attackers)
            {
                Console.WriteLine("| {0, -9} | {1, -10} | {2, 9} |", person.Name, person.Surname, person.Height, Encoding.UTF8);
            }
        }
        /// <summary>
        /// Method prints the data of invited candidates to the file
        /// </summary>
        public static void PrintInvitedPeopleToCSVFile(string fileName, List<Person> InvitedPeople)
        {
            string[] lines = new string[InvitedPeople.Count];
            string info;
            info = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}",
           "Vardas", "Pavardė", "Gimimo data", "Ūgis (cm)", "Pozicija", "Klubo pavadinimas",
           "Ar pakviestas?", "Ar kapitonas ?");
            File.WriteAllText(fileName, info + Environment.NewLine, Encoding.UTF8);
            for (int i = 0; i < InvitedPeople.Count; i++)
            {
                lines[i] = String.Format("{0},{1},{2:yyy-MM-dd},{3},{4},{5},{6},{7}",
                InvitedPeople[i].Name, InvitedPeople[i].Surname, InvitedPeople[i].BirthDate, InvitedPeople[i].Height, 
                InvitedPeople[i].Position, InvitedPeople[i].Club,  InvitedPeople[i].Invited, InvitedPeople[i].Captain);
            }
            File.AppendAllLines(fileName, lines, Encoding.UTF8);
        }
    }
}
