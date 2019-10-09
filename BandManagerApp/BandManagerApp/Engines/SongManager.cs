using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BandManagerApp.DataEntities;
using BandManagerApp.DataContexsts;

namespace BandManagerApp.Engines
{
    public class SongManager
    {
        public List<Song> GetListofSongs(Band band)
        {
            using(var context = new DBContext())
            {
                var songs = context.Songs.Include("Band").ToList().Where(something => something.Band.Name == band.Name);
                return songs.ToList();
            }
        }

        public void AddSong(Song song)
        {
            using(var context = new DBContext())
            {
                context.Songs.Add(song);
                context.SaveChanges();
            }
        }

        public void RemoveSong(Song song)
        {
            using (var context = new DBContext())
            {
                context.Songs.Remove(song);
                context.SaveChanges();
            }
        }
    }
}
