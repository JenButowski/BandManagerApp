using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BandManagerApp.DataEntities;
using BandManagerApp.Enums;

namespace BandManagerApp.DataContexsts
{
    public class DBContext : DbContext
    {
        public DbSet<Band> Bands { get; set; }

        public DbSet<Musician> Musicians { get; set; }

        public DbSet<Song> Songs { get; set; }

        public DbSet<Concert> Concerts { get; set; }

        public DbSet<Tour> Tours { get; set; }

        public DBContext() : base("DBContext")
        { }

        //public static dynamic GetInstanceList(DataInstances instance, string sortParams = "Musicians")
        //{
        //    try
        //    {
        //        using (var context = new DBContext())
        //        {
        //            switch (instance)
        //            {
        //                case DataInstances.Bands:
        //                    var contex = context.Bands.Include(something => something.LastTour).ToList();
        //                    return contex;
        //                case DataInstances.Concerts:
        //                    return context.Concerts.ToList();
        //                case DataInstances.Musicians:
        //                    return context.Musicians.ToList();
        //                case DataInstances.Songs:
        //                    return context.Songs.ToList();
        //                case DataInstances.Tours:
        //                    return context.Tours.Include(sortParams).ToList();
        //            }
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Red;
        //        Console.WriteLine(ex.Message);
        //    }
        //    return null;
        //}
    }
}
