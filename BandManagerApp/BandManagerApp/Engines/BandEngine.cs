using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BandManagerApp.DataContexsts;
using BandManagerApp.DataEntities;

namespace BandManagerApp.Engines
{
    public class BandEngine
    {
        public List<Band> GetBands(Manager manager)
        {
            using (var context = new DBContext())
            {
                var bands = context.Bands.Include("Manager").ToList().Where(something => something.ManagerId == manager.Id);
                return bands.ToList();
            }
        }

        public Band GetBand(Manager manager, string name)
        {
            using (var context = new DBContext())
            {
                var band = context.Bands.Include("Manager").ToList().Where(something => something.ManagerId == manager.Id && something.Name == name).First();
                return band;
            }
        }

        public void AddBand(Band band)
        {
            using (var context = new DBContext())
            {
                context.Bands.Add(band);
                context.SaveChanges();
            }
        }
    }
}
