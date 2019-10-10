using BandManagerApp.DataContexsts;
using BandManagerApp.DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandManagerApp.Engines
{
    class ManagerEngine
    {
        public List<Manager> Managers()
        {
            using(var context = new DBContext())
            {
                var managers = context.Managers.Include("Bands").ToList();
                return managers;
            }
        }

        public void AddManager(Manager manager)
        {
            using(var context = new DBContext())
            {
                context.Managers.Add(manager);
                context.SaveChanges();
            }
        }
    }
}
