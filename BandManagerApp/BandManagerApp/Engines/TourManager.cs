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
            using(var context = new DBContext())
            {
                var tour = new Tour() { Id = id, Name = name, StartDate = startDate, EndDate = endDate, Concerts = concerts, Band = band };
                context.Tours.Add(tour);
                context.SaveChanges();
            }
        }

        public void RemoveTour(string name)
        {

        }
    }
}
