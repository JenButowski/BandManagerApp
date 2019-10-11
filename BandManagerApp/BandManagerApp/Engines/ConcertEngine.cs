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
        public List<Concert> GetAllTourConcerts(Tour tour)
        {
            using(var context = new DBContext())
            {
                var concerts = context.Concerts.Include("Tour").ToList().Where(something => something.TourId == tour.Id);
                return concerts.ToList();
            }
        }

        public bool AddConcertToTour(Concert concert)
        {
            try
            {
                using (var context = new DBContext())
                {
                    context.Concerts.Add(concert);
                    context.SaveChanges();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public void RemoveConcert(Concert concert)
        {
            using (var context = new DBContext())
            {
                context.Concerts.Remove(concert);
                context.SaveChanges();
            }
        }
    }
}
