using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BandManagerApp.DataContexsts;
using BandManagerApp.Engines;
using Newtonsoft.Json;

namespace WebAPI.Controllers
{
    public class BandsController : Controller
    {
        private BandEngine bandEngine = new BandEngine();

        public string GetBands(string login, string password)
        {
            try
            {
                using (var context = new DBContext())
                {
                    var manager = new ManagerEngine().CheckManagerData(context, login, password);
                    var bands = bandEngine.GetBands(context, manager);

                    return JsonConvert.SerializeObject(bands);
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}