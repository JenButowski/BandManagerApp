using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BandManagerApp.DataContexsts;
using BandManagerApp.DataEntities;
using BandManagerApp.Engines;
using BandManagerApp.GUIs.ConsoleGUI;

namespace BandManagerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleGraphic consoleGraphic = new ConsoleGraphic();
            ConcertEngine concertEngine = new ConcertEngine();
            TourEngine tourEngine = new TourEngine();

            consoleGraphic.PrintConcerts(concertEngine, tourEngine.GetAllTours().Last());
            Console.ReadLine();
        }
    }
}
