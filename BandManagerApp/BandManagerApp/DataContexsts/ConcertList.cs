using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BandManagerApp.DataEntities;

namespace BandManagerApp.DataContexsts
{
    public class ConcertList : DbContext
    {
        public DbSet<Concert> List { get; set; }

        public ConcertList() : base("Concerts")
        { }
    }
}
