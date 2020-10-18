using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace U2_2.Register
{
    class VehiclesRegister
    {
        private List<Vehicle> AllVehicles; // list of vehicles
        public VehiclesRegister()
        {
            AllVehicles = new List<Vehicle>();
        }
        public VehiclesRegister(List<Vehicle> Vehicles)
        {
            AllVehicles = new List<Vehicle>();
            foreach (Vehicle vehicle in Vehicles)
            {
                this.AllVehicles.Add(vehicle);
            }
        }
        /// <summary>
        /// Method adds a vehicle to the list
        /// </summary>
        /// <param name="vehicle"></param>
        public void Add (Vehicle vehicle)
        {
            AllVehicles.Add(vehicle);
        }
        /// <summary>
        /// Method prints startting data to txt file
        /// </summary>
        /// <param name="fileName"></param>
        public void PrintToTxt(string fileName)
        {
            string[] lines = new string[AllVehicles.Count];
            string space = new string("");
            string info = String.Format("| {0, 7} | {1, -10} | {2, -9} | {3, 5} | {4, 5} | {5, 19} | {6, -9} | {7, 15:f}",
           "Numeris", "Gamintojas", "Modelis", "Metai", "Mėnuo", "Tech. ap. gal. data", "Kuras", "Vid. sąnaudos |" + Environment.NewLine);
            for (int i = 0; i < AllVehicles.Count; i++)
            {
                lines[i] = String.Format("| {0, 7} | {1, -10} | {2, -9} | {3, 5} | {4, 5} | {5, 19:yyy-MM-dd } | {6, -9} | {7, 15:f} |",
                    AllVehicles[i].LicensePlate, AllVehicles[i].Producer, AllVehicles[i].Model, AllVehicles[i].YearOfProduction,
                    AllVehicles[i].MonthOfProduction, AllVehicles[i].TechnicalInspection, AllVehicles[i].Fuel, AllVehicles[i].AverageFuelConsumption);
            }
                File.WriteAllText(fileName, info + Environment.NewLine, Encoding.UTF8);
                File.AppendAllLines(fileName, lines, Encoding.UTF8);
        }
        /// <summary>
        /// Method prints the given list of data
        /// </summary>
        public void PrintVehicles()
        {
            Console.WriteLine("UAB „Žaibas {0}“ priklausantys automobiliai:", AllVehicles[0].City);
            Console.WriteLine(new string('-', 104));
            Console.WriteLine("| {0, 7} | {1, -10} | {2, -9} | {3, 5} | {4, 5} | {5, 19} | {6, -9} | {7, 15:f} |",
           "Numeris", "Gamintojas", "Modelis", "Metai", "Mėnuo", "Tech. ap. gal. data", "Kuras", "Vid. sąnaudos");
            Console.WriteLine(new string('-', 104));
            foreach (Vehicle vehicle in this.AllVehicles)
            {
                Console.WriteLine("| {0, 7} | {1, -10} | {2, -9} | {3, 5} | {4, 5} | {5, 19:yyy-MM-dd } | {6, -9} | {7, 15:f} |",
                    vehicle.LicensePlate, vehicle.Producer, vehicle.Model, vehicle.YearOfProduction,
                    vehicle.MonthOfProduction, vehicle.TechnicalInspection, vehicle.Fuel, vehicle.AverageFuelConsumption);
            }
            Console.WriteLine(new string('-', 104));
        }/// <summary>
        /// Method finds all the different car producers
        /// </summary>
        /// <returns></returns>
        public List<string> FindProducers()
        {
            List<string> producers = new List<string>();
            foreach (Vehicle vehicle in AllVehicles)
            {
                string producer = vehicle.Producer;
                if (!producers.Contains(producer))
                {
                    producers.Add(producer);
                }
            }
            return producers;
        }
        /// <summary>
        /// Method creates new list with filtered producers and new segment for counting the quantity of producer's cars
        /// </summary>
        /// <param name="filteredProducers"></param>
        /// <returns></returns>
        public List<Producer> ListOfStringsToProducerObjects(List<string> filteredProducers)
        {
            List<Producer> allProducers = new List<Producer>();
            foreach (string newProducer in filteredProducers)
            {
                Producer producer = new Producer(newProducer, 0);
                allProducers.Add(producer);
            }
            return allProducers;
        }
        /// <summary>
        /// Method counts how many vehicles each producer has
        /// </summary>
        /// <param name="filteredProducers"></param>
        /// <param name="vehicles"></param>
        public List<Producer> CountVehiclesByProducers(List<Producer> filteredProducers)
        {

            for (int i = 0; i < filteredProducers.Count; i++)
            {
                int NumberOfVehicles = CountingOfVehiclesByProducer(filteredProducers[i].ProducerName);
                filteredProducers[i].NumberOfVehicles = NumberOfVehicles;
            }
            return filteredProducers;
        }
        /// <summary>
        /// Method counts how many vehicles a producer has
        /// </summary>
        /// <param name="ProducerName"></param>
        /// <returns></returns>
        public int CountingOfVehiclesByProducer(string ProducerName)
        {
            int NumberOfVehicles = 0;
            foreach (Vehicle vehicle in AllVehicles)
            {
                if (vehicle.Producer == ProducerName)
                {
                    NumberOfVehicles++;
                }
            }
            return NumberOfVehicles;
        }
        /// <summary>
        /// Method searches for highest number of vehicles per producers
        /// </summary>
        /// <param name="filteredProducers"></param>
        /// <returns></returns>
        public int HighestNumber(List<Producer> filteredProducers)
        {
            int highestNumber = 0;
            foreach (Producer producer in filteredProducers)
            {
                if (highestNumber < producer.NumberOfVehicles)
                    highestNumber = producer.NumberOfVehicles;
            }
            return highestNumber;
        }
        /// <summary>
        /// Method makes a list of the newest vehicles
        /// </summary>
        /// <returns></returns>
        public List<Vehicle> FindNewestVehicles()
        {
            List<Vehicle> NewestVehicles = new List<Vehicle>();

            foreach (Vehicle vehicle in AllVehicles)
            {
                if (vehicle.Age == NewestVehicleDate().Age)
                {
                    NewestVehicles.Add(vehicle);
                }
            }
            return NewestVehicles;
        }
        /// <summary>
        /// Method finds the newest vehicle
        /// </summary>
        /// <returns></returns>
        private Vehicle NewestVehicleDate()
        {
            Vehicle NewestVehicle = AllVehicles[0];
            foreach (Vehicle vehicle in AllVehicles)
            {
                if (vehicle < NewestVehicle)
                {
                    NewestVehicle = vehicle;
                }
            }
            return NewestVehicle;
        }
        /// <summary>
        /// Method finds vehicles with expired technical inspection and adds them to a list
        /// </summary>
        /// <returns></returns>
        public List<Vehicle> FindVehiclesWithExpiredTI()
        {
            List<Vehicle> VehiclesWithExpiredTI = new List<Vehicle>();
            DateTime Today = DateTime.Today;
            foreach(Vehicle vehicle in AllVehicles)
            {
                if(Today.Year > vehicle.TechnicalInspection.Year)
                {
                    vehicle.TechnicalInspection = Convert.ToDateTime("1111/1/1");
                    VehiclesWithExpiredTI.Add(vehicle);
                }
                else if (vehicle.TechnicalInspection.Year == Today.Year && vehicle.TechnicalInspection.Month - vehicle.TechnicalInspection.Month <= 1)
                {
                    VehiclesWithExpiredTI.Add(vehicle);
                }
            }
            return VehiclesWithExpiredTI;
        }
    }
}