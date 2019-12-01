using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BandManagerApp.DataEntities;
using BandManagerApp.DataContexsts;

namespace BandManagerApp.Engines
{
    public class ConcertEngine
    {
        public List<Concert> GetAllTourConcerts(DBContext context, Tour tour)
        {
            var concerts = context.Concerts.Include("Tour").ToList().Where(something => something.Tour.Name == tour.Name);
            return concerts.ToList();
        }

        public bool AddConcertToTour(DBContext context, Concert concert)
        {
            try
            {
                context.Concerts.Add(concert);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void RemoveConcert(DBContext context, Concert concert)
        {

            context.Concerts.Remove(concert);
            context.SaveChanges();
        }
    }
}
