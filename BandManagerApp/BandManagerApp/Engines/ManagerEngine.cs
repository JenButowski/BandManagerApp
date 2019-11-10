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
        public Manager CheckManagerData(DBContext context, string login, string password)
        {
            var managers = GetManagers(context);

            foreach (var manager in managers)
            {
                if (manager.Login == login && manager.Password == password)
                    return manager;
            }
            return null;
        }

        public void AddManager(DBContext context, Manager manager)
        {
            context.Managers.Add(manager);
            context.SaveChanges();
        }

        public List<Manager> GetManagers(DBContext context)
        {
            var managers = context.Managers.Include("Bands").ToList();
            return managers;
        }
    }
}
