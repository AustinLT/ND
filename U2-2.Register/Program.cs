using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace U2_2.Register
{
    public class Program
    {
        /// <summary>
        /// Main method
        /// </summary>
        /// <param name="args"> program's arguments </param>
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            if (new FileInfo(@"Duomenys5.txt").Length <= 3 && new FileInfo(@"Duomenys6.txt").Length <= 3)
            {
                Console.WriteLine("Duomenų failai tušti");
            }
            else
            {
                if (new FileInfo(@"Duomenys5.txt").Length <= 3)
                {
                    Console.WriteLine("Pirmasis failas tuščias");

                    Console.WriteLine("Antrasis registras");
                    VehiclesRegister register2 = InOutUtils.ReadVehicles(@"Duomenys6.txt");
                    register2.PrintToTxt("DuomenysPradiniai2.txt");
                    register2.PrintVehicles();
                    Console.WriteLine();
                    Console.WriteLine("Daugiausiai vieno gamintojo (gamintojų) automobilių:");
                    InOutUtils.PrintingVehiclesByProducers(register2);
                    Console.WriteLine();
                    List<Vehicle> NewestVehicles = register2.FindNewestVehicles();
                    Console.WriteLine("Naujausias(-i) automobilis(-iai):");
                    InOutUtils.PrintNewestVehicles(NewestVehicles);
                    Console.WriteLine();
                    List<Vehicle> VehiclesWithExpiredTI = register2.FindVehiclesWithExpiredTI();
                    if (VehiclesWithExpiredTI.Count == 0)
                    {
                        Console.WriteLine("Automobilių su pasibaigusiu T.A. nėra");
                        Console.WriteLine();
                    }
                    else
                    {
                        InOutUtils.PrintVehiclesWithExpiredTIToCSV(VehiclesWithExpiredTI, "Apžiūra2.csv");
                    }
                    Console.ReadKey();
                }
                if (new FileInfo(@"Duomenys6.txt").Length <= 3)
                {
                    VehiclesRegister register1 = InOutUtils.ReadVehicles(@"Duomenys5.txt");
                    register1.PrintToTxt("DuomenysPradiniai1.txt");
                    register1.PrintVehicles();
                    Console.WriteLine();

                    InOutUtils.PrintingVehiclesByProducers(register1);
                    Console.WriteLine();
                    List<Vehicle> NewestVehicles = register1.FindNewestVehicles();
                    Console.WriteLine("Naujausias(-i) automobilis(-iai):");
                    InOutUtils.PrintNewestVehicles(NewestVehicles);
                    Console.WriteLine();
                    List<Vehicle> VehiclesWithExpiredTI = register1.FindVehiclesWithExpiredTI();
                    if (VehiclesWithExpiredTI.Count == 0)
                    {
                        Console.WriteLine("Automobilių su pasibaigusiu T.A. nėra");
                        Console.WriteLine();
                    }
                    else
                    {
                        InOutUtils.PrintVehiclesWithExpiredTIToCSV(VehiclesWithExpiredTI, "Apžiūra1.csv");
                    }
                    Console.WriteLine("Antrasis failas tuščias");
                }
                else
                {
                    VehiclesRegister register1 = InOutUtils.ReadVehicles(@"Duomenys5.txt");
                    register1.PrintToTxt("DuomenysPradiniai1.txt");
                    register1.PrintVehicles();
                    Console.WriteLine();

                    InOutUtils.PrintingVehiclesByProducers(register1);
                    Console.WriteLine();
                    List<Vehicle> NewestVehicles = register1.FindNewestVehicles();
                    Console.WriteLine("Naujausias(-i) automobilis(-iai):");
                    InOutUtils.PrintNewestVehicles(NewestVehicles);
                    Console.WriteLine();
                    List<Vehicle> VehiclesWithExpiredTI = register1.FindVehiclesWithExpiredTI();
                    if (VehiclesWithExpiredTI.Count == 0)
                    {
                        Console.WriteLine("Automobilių su pasibaigusiu T.A. nėra");
                        Console.WriteLine();
                    }
                    else
                    {
                        InOutUtils.PrintVehiclesWithExpiredTIToCSV(VehiclesWithExpiredTI, "Apžiūra1.csv");
                    }

                    Console.WriteLine("Antrasis registras");
                    VehiclesRegister register2 = InOutUtils.ReadVehicles(@"Duomenys6.txt");
                    register2.PrintToTxt("DuomenysPradiniai2.txt");
                    register2.PrintVehicles();
                    Console.WriteLine();
                    Console.WriteLine("Daugiausiai vieno gamintojo (gamintojų) automobilių:");
                    InOutUtils.PrintingVehiclesByProducers(register2);
                    Console.WriteLine();
                    NewestVehicles = register2.FindNewestVehicles();
                    Console.WriteLine("Naujausias(-i) automobilis(-iai):");
                    InOutUtils.PrintNewestVehicles(NewestVehicles);
                    Console.WriteLine();
                    VehiclesWithExpiredTI = register2.FindVehiclesWithExpiredTI();
                    if (VehiclesWithExpiredTI.Count == 0)
                    {
                        Console.WriteLine("Automobilių su pasibaigusiu T.A. nėra");
                        Console.WriteLine();
                    }
                    else
                    {
                        InOutUtils.PrintVehiclesWithExpiredTIToCSV(VehiclesWithExpiredTI, "Apžiūra2.csv");
                    }
                    Console.ReadKey();
                }
            }
        }
    }
}
