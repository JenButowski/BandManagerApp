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
        public Manager CheckManagerData(string login, string password)
        {
            var managers = GetManagers();

            foreach(var manager in managers)
            {
                if (manager.Login == login && manager.Password == password)
                    return manager;
            }
            return null;
        }

        public void AddManager(Manager manager)
        {
            using(var context = new DBContext())
            {
                context.Managers.Add(manager);
                context.SaveChanges();
            }
        }

        public List<Manager> GetManagers()
        {
            using (var context = new DBContext())
            {
                var managers = context.Managers.Include("Bands").ToList();
                return managers;
            }
        }
    }
}
