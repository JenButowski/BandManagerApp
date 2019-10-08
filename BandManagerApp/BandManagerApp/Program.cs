using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BandManagerApp.DataContexsts;
using BandManagerApp.DataEntities;
using BandManagerApp.Engines;

namespace BandManagerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TourManager tourManager = new TourManager();
            tourManager.RemoveTour("The Song");

            Console.WriteLine("Complete");
            Console.ReadLine();
        }
    }
}
