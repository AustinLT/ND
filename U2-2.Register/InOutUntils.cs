using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace U2_2.Register
{
    /// <summary>
    /// Class containing reading and priniting methods
    /// </summary>
    static class InOutUtils//
    {
    /// <summary>
    /// method that reads the data from the file
    /// </summary>
    /// <param name="fileName"> file which contains needed data </param>
    /// <returns></returns>
        public static VehiclesRegister ReadVehicles(string fileName)
        {
                VehiclesRegister vehicles = new VehiclesRegister();
                using (StreamReader reader = new StreamReader(fileName))
                {
                    string line = null;
                    string city = reader.ReadLine();
                    string address = reader.ReadLine();
                    string phoneNum = reader.ReadLine();
                    while (null != (line = reader.ReadLine()))
                    {
                        string[] values = line.Split(';');
                        string licensePlate = values[0];
                        string producer = values[1];
                        string model = values[2];
                        int yearOfProduction = int.Parse(values[3]);
                        int monthOfProduction = int.Parse(values[4]);
                        DateTime technicalInspection = DateTime.Parse(values[5]);
                        string fuel = values[6];
                        double averageFuelConsumption = double.Parse(values[7]);

                        Vehicle vehicle = new Vehicle(licensePlate, producer, model, yearOfProduction, monthOfProduction, 
                            technicalInspection, fuel, averageFuelConsumption, city, address, phoneNum);
                        if (!vehicles.Equals(vehicle))
                        {
                            vehicles.Add(vehicle);
                        }
                    }
                }
                return vehicles;
        }
        /// <summary>
        /// Method prints the most common producer(s)
        /// </summary>
        /// <param name="allVehicles"></param>
        public static void PrintingVehiclesByProducers (VehiclesRegister register)
        {
            List<string> producers = register.FindProducers();
            List<Producer> filteredProducersWithNumberOfCars = register.ListOfStringsToProducerObjects(producers);
            List<Producer> filteredProducers = register.CountVehiclesByProducers(filteredProducersWithNumberOfCars);
            int HighestNumber = register.HighestNumber(filteredProducers);

            Console.WriteLine("Daugiausiai automobilių turi: ");
            Console.WriteLine("| {0} | {1}| ", "Gamintojas(-ai)", "Automobilių kiekis");
            Console.WriteLine(new string('-', 39));
            foreach (Producer producer in filteredProducers) //searching producer with the most vehicles
            {
                if (producer.NumberOfVehicles == HighestNumber)
                {
                    Console.WriteLine("| {0,-15} | {1,17} |", producer.ProducerName, producer.NumberOfVehicles);
                }
            }
        }
        /// <summary>
        /// Method prints the newest vehicles
        /// </summary>
        /// <param name="Vehicles"></param>
        public static void PrintNewestVehicles(List<Vehicle> Vehicles)
        {
            Console.WriteLine("| {0} | {1} | {2} | {3} | {4} | {5} | {6,8} | {7} |", 
                "Valstybinis numeris", "Gamintojas", "Modelis", "Pagaminimo metai", "Pagaminimo mėnuo",
                "T.A. galiojimo data", "Kuras", "Vid. sąnaudos");
            Console.WriteLine(new string('-', 133));
            foreach(Vehicle vehicle in Vehicles)
            {
                Console.WriteLine("| {0,-19} | {1,-10} | {2,-7} | {3,16} | {4,16} | {5,19:yyyy-MM-dd} | {6,-8} | {7,13:f} |", 
                    vehicle.LicensePlate, vehicle.Producer, vehicle.Model, vehicle.YearOfProduction, vehicle.MonthOfProduction,
                    vehicle.TechnicalInspection, vehicle.Fuel, vehicle.AverageFuelConsumption);
            }
        }
        /// <summary>
        /// Method print vehicles with expired technical inspections to a CSV file
        /// </summary>
        /// <param name="Vehicles"></param>
        /// <param name="fileName"></param>
        public static void PrintVehiclesWithExpiredTIToCSV (List<Vehicle> Vehicles, string fileName)
        {
            string[] lines = new string[Vehicles.Count + 1];
            lines[0] = String.Format("{0},{1},{2},{3},{4},{5},{6},{7}", "Valstybinis numeris", 
                "Gamintojas", "Modelis", "Pagaminimo metai", "Pagaminimo mėnuo",
                "T.A. galiojimo data", "Kuras", "Vid. sąnaudos");
            for (int i = 1; i < Vehicles.Count; i++)
            {
                if (Vehicles[i].TechnicalInspection == Convert.ToDateTime("1111/1/1"))
                {
                    lines[i] = String.Format("{0},{1},{2},{3},{4},{5},{6},{7:f}", Vehicles[i].LicensePlate, 
                        Vehicles[i].Producer, Vehicles[i].Model, Vehicles[i].YearOfProduction,
                        Vehicles[i].MonthOfProduction, "SKUBIAI", Vehicles[i].Fuel, Vehicles[i].AverageFuelConsumption);
                }
                else
                {
                    lines[i] = String.Format("{0},{1},{2},{3},{4},{5:yyyy-MM-dd},{6},{7:f}", Vehicles[i].LicensePlate, 
                        Vehicles[i].Producer, Vehicles[i].Model, Vehicles[i].YearOfProduction,
                        Vehicles[i].MonthOfProduction, Vehicles[i].TechnicalInspection, Vehicles[i].Fuel, Vehicles[i].AverageFuelConsumption);
                }
                    File.WriteAllLines(fileName, lines, Encoding.UTF8);
            }
        }
    }
}
