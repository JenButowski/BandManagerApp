using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BandManagerApp.Enums;
using Newtonsoft.Json;

namespace BandManagerApp.DataEntities
{
    public class Musician
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public BandRoles BandRole { get; set; }

        public int? BandId { get; set; }

        [JsonIgnore]
        public Band Band { get; set; }
    }
}
