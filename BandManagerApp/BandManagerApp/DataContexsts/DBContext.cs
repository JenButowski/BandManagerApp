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
        public DbSet<Manager> Managers { get; set; }

        public DbSet<Band> Bands { get; set; }

        public DbSet<Musician> Musicians { get; set; }

        public DbSet<Song> Songs { get; set; }

        public DbSet<Concert> Concerts { get; set; }

        public DbSet<Tour> Tours { get; set; }

        public DBContext() : base("DBContext")
        { }
    }
}
