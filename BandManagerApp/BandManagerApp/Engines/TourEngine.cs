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
        public void AddTour(Tour tour)
        {
            using (var context = new DBContext())
            {
                context.Tours.Add(tour);
                context.SaveChanges();
            }
        }

        public Tour GetTourbyName(string name)
        {
            using(var context = new DBContext())
            {
                var tour = context.Tours.Include("Concerts").ToList().Where(something => something.Name == name).LastOrDefault();
                return tour;
            }
        }

        public List<Tour> GetAllTours()
        {
            using(var context = new DBContext())
            {
                var tours = context.Tours.Include("Concerts").ToList();
                return tours;
            }
        }

        public void RemoveTour(Tour tour)
        {
            try
            {
                using (var context = new DBContext())
                {
                    RemoveAllRelatedConcerts(tour, context);
                    context.Tours.Remove(tour);
                    context.SaveChanges();
                }
            }
            catch
            {
                Console.WriteLine("Problems with removing tour");
            }
        }

        private void RemoveAllRelatedConcerts(Tour tour, DBContext context)
        {
            try
            {
                var concerts = context.Concerts.Include("Tour").ToList().Where(something => something.TourId == tour.Id);
                context.Concerts.RemoveRange(concerts.ToList());
            }
            catch
            {
                Console.WriteLine("Problems with removing related concerts");
            }
        }
    }
}
