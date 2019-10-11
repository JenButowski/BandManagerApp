using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BandManagerApp.DataEntities;
using BandManagerApp.Engines;

namespace BandManagerApp.GUIs.ConsoleGUI
{
    class ConsoleGraphic
    {
        public bool PrintUserLogForm(ManagerEngine managerEngine)
        {
            Console.WriteLine("Band Manager v 1.0");
            Console.WriteLine();
            Console.WriteLine("Введите логин :");
            string login = Console.ReadLine();
            Console.WriteLine("Введите пароль :");
            string password = Console.ReadLine();
            return managerEngine.CheckManagerData(login, password);
        }

        public void PrintBands(BandEngine bandEngine, Manager manager)
        {
            var bands = bandEngine.GetBands(manager);
            int counter = 2;
            Console.WriteLine("Группы :");

            foreach(var band in bands)
            {
                if (counter % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"{band.Name} {band.Country} {band.PlayGenre} {band.DateofCreation.ToString("yyyy/MM/dd")}");
                    Console.ResetColor();
                    Console.WriteLine();
                }
                counter++;
            }
        }

        public void PrintConcerts(ConcertEngine concertEngine, Tour tour)
        {
            var concerts = concertEngine.GetAllTourConcerts(tour);
            int counter = 2;
            Console.WriteLine("Концерты :");

            foreach (var concert in concerts)
            {
                if (counter % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"{concert.City} {concert.StartDate.ToString()} {concert.StartDate.ToString()}");
                    Console.ResetColor();
                    Console.WriteLine();
                }
                counter++;
            }
        }
    }
}
