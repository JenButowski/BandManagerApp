using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BandManagerApp.DataContexsts;
using BandManagerApp.DataEntities;

namespace BandManagerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var bandlist = new BandList())
            {
                foreach (var band in bandlist.List)
                {
                    Console.WriteLine($"{band.Name} {band.PlayGenre} {band.Rate} {band.Musicians.FirstOrDefault().BandRole}");
                }
                Console.WriteLine("Complete");
            }
            Console.ReadLine();
        }
    }
}
