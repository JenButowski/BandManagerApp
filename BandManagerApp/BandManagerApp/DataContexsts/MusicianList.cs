using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BandManagerApp.DataEntities;

namespace BandManagerApp.DataContexsts
{
    class MusicianList : DbContext
    {
        public DbSet<Musician> List { get; set; }

        public MusicianList() : base ("Musicians")
        { }
    }
}
