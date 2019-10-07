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
            var concerts = DBContext.GetInstanceList(Enums.DataInstances.Bands);
            foreach(Band context in concerts)
            {
                foreach(Musician musicians in context.Musicians)
                Console.WriteLine($"{context.Name} {musicians.Name} {musicians.Surname} {musicians.BandRole.ToString()}");
            }
            Console.WriteLine("Complete");
            Console.ReadLine();
        }
    }
}
