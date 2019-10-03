using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BandManagerApp.Enums;

namespace BandManagerApp.DataEntities
{
    public class Musician
    {
        public int Id { get; set; }

        public int BandId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public BandRoles BandRole { get; set; }
    }
}
