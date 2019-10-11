using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BandManagerApp.DataEntities;
using BandManagerApp.DataContexsts;

namespace BandManagerApp.Engines
{
    public class SongEngine
    {
        public List<Song> GetListofSongs(Band band)
        {
            using(var context = new DBContext())
            {
                var songs = context.Songs.Include("Band").ToList().Where(something => something.Band.Name == band.Name);
                return songs.ToList();
            }
        }

        public bool AddSong(Song song)
        {
            try
            {
                using (var context = new DBContext())
                {
                    context.Songs.Add(song);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
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

        public Song GetSongbyName(string songName)
        {
            using(var context = new DBContext())
            {
                var songs = context.Songs.Include("Band").ToList();
                var song = songs.Where(something => something.Name == songName).LastOrDefault();
                return song;
            }
        }

        public List<Song> GetSongsbyBand(Band band)
        {
            using(var context = new DBContext())
            {
                var songs = context.Songs.Include("Band").ToList().Where(something => something.Band.Name == band.Name);
                return songs.ToList();
            }
        }
    }
}
