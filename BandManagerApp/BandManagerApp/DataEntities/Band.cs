using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BandManagerApp.DataEntities
{
    public class Band
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateofCreation { get; set; }

        public string Country { get; set; }

        public string PlayGenre { get; set; }

        [JsonIgnore]
        public List<Musician> Musicians { get; set; }

        [JsonIgnore]
        public List<Song> Songs { get; set; }

        [JsonIgnore]
        public Tour LastTour { get; set; }

        public int Rate { get; set; }

        [JsonIgnore]
        public int ManagerId { get; set; }

        [JsonIgnore]
        public Manager Manager { get; set; }
    }
}
