using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BandManagerApp.DataEntities;

namespace BandManagerApp.DataContexsts
{
    public class SongList : DbContext
    {
        public DbSet<Song> List { get; set; }

        public SongList() : base("Songs")
        { }
    }
}
