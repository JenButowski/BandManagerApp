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
        public List<Song> GetListofSongs(DBContext context, Band band)
        {
            var songs = context.Songs.Include("Band").ToList().Where(something => something.Band.Name == band.Name);
            return songs.ToList();
        }

        public bool AddSong(DBContext context, Song song)
        {
            try
            {
                context.Songs.Add(song);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void RemoveSong(DBContext context, Song song)
        {
            context.Songs.Remove(song);
            context.SaveChanges();
        }

        public Song GetSongbyName(DBContext context, string songName)
        {
            var songs = context.Songs.Include("Band").ToList();
            var song = songs.Where(something => something.Name == songName).LastOrDefault();
            return song;
        }

        public List<Song> GetSongsbyBand(DBContext context, Band band)
        {

            var songs = context.Songs.Include("Band").ToList().Where(something => something.Band.Name == band.Name);
            return songs.ToList();
        }
    }
}
