using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BandManagerApp.DataContexsts;
using BandManagerApp.DataEntities;

namespace BandManagerApp.Engines
{
    class TourManager
    {
        public void AddTour(int id, string name, DateTime startDate, DateTime endDate, List<Concert> concerts, Band band)
        {
            using (var context = new DBContext())
            {
                var tour = new Tour() { Id = id, Name = name, StartDate = startDate, EndDate = endDate, Concerts = concerts, Band = band };
                context.Tours.Add(tour);
                context.SaveChanges();
            }
        }

        public void RemoveTour(string name)
        {
            try
            {
                using (var context = new DBContext())
                {
                    var tour = context.Tours.Include("Concerts").ToList().Find(something => something.Name == name);
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
                context.SaveChanges();
            }
            catch
            {
                Console.WriteLine("Problems with removing related concerts");
            }
        }
    }
}
