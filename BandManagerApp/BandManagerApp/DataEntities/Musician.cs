using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BandManagerApp.Enums;

namespace BandManagerApp.DataEntities
{
    public class Musician
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public BandRoles BandRole { get; set; }

        [ForeignKey("Band")]
        public string BandName { get; set; }

        public Band Band { get; set; }
    }
}
