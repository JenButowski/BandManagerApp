using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BandManagerApp.DataContexsts;
using BandManagerApp.DataEntities;

namespace BandManagerApp.Engines
{
    class TourEngine
    {
        public void AddTour(DBContext context, Tour tour)
        {
            context.Tours.Add(tour);
            context.SaveChanges();
        }

        public Tour GetTourbyName(DBContext context, string name)
        {
            var tour = context.Tours.Include("Concerts").ToList().Where(something => something.Name == name).First();
            return tour;
        }

        public List<Tour> GetAllTours(DBContext context)
        {
            var tours = context.Tours.Include("Concerts").ToList();
            return tours;
        }

        public void RemoveTour(DBContext context, Tour tour)
        {
            try
            {
                RemoveAllRelatedConcerts(tour, context);
                context.Tours.Remove(tour);
                context.SaveChanges();
            }
            catch
            { }
        }

        private void RemoveAllRelatedConcerts(Tour tour, DBContext context)
        {
            try
            {
                var concerts = context.Concerts.Include("Tour").ToList().Where(something => something.Tour.Name == tour.Name);
                context.Concerts.RemoveRange(concerts.ToList());
            }
            catch
            { }
        }
    }
}
