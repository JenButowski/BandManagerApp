using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BandManagerApp.DataEntities;

namespace BandManagerApp.DataContexsts
{
    public class BandList : DbContext
    {
        public DbSet<Band> List { get; set; }

        public BandList() : base("Bands")
        { }
    }
}
