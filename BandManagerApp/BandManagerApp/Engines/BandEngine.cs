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
        public List<Band> GetBands(DBContext context, Manager manager)
        {
            var bands = context.Bands.Include("Manager").ToList().Where(something => something.ManagerId == manager.Id);
            return bands.ToList();
        }

        public Band GetBandbyName(DBContext context, string name)
        {
            var band = context.Bands.Include("Songs").ToList().Where(something => something.Name == name).LastOrDefault();
            return band;
        }

        public void AddBand(DBContext context, Band band)
        {
            context.Bands.Add(band);
            context.SaveChanges();
        }
    }
}
