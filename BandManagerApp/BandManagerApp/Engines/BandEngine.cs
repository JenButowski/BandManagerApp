﻿using System;
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

        public Band GetBandbyName(string name)
        {
            using (var context = new DBContext())
            {
                var band = context.Bands.Include("Songs").ToList().Where(something => something.Name == name).LastOrDefault();
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
