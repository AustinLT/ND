using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace U1_1.Register
{
    class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        static void Main(string[] args)
        {
            
            Console.OutputEncoding = Encoding.UTF8;
            if (new FileInfo("Candidates1.txt").Length <= 0)
            {
                Console.WriteLine("Duomenų failas tuščias");
            }
            else
            {
                List<Person> AllPeople = InOutUtils.ReadPeople("Candidates1.txt");
                if (TaskUtils.CheckIfAnyInvited(AllPeople) > 0)
                {

                    InOutUtils.PrintAllPeople("Duomenys.txt", AllPeople);

                    List<Person> OldestCandidates = TaskUtils.FindOldestPerson(AllPeople);
                    Console.WriteLine("Vyriausias(-i) kandidatas(-i): ");
                    InOutUtils.PrintOldestCandidates(OldestCandidates);
                    if (TaskUtils.CheckIfAnyAttackersInvited(AllPeople) > 0)
                    {
                        Console.WriteLine("Puolėjai", Encoding.UTF8);
                        List<Person> Attackers = TaskUtils.FindAttackers(AllPeople);
                        InOutUtils.PrintAttackers(Attackers);
                    }
                    else
                    {
                        Console.WriteLine("Nebuvo jokie puolėjai pakviesti");
                    }

                    List<Person> InvitedPeople = TaskUtils.FindInvitedPeople(AllPeople);
                    InOutUtils.PrintInvitedPeopleToCSVFile("Rinktinė.csv", InvitedPeople);
                }
                else
                {
                    Console.WriteLine("Niekas nebuvo pakviestas");
                }
            }
        }
    }
}
