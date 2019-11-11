using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BandManagerApp.DataEntities
{
    public class Concert
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string City { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int? TourId { get; set; }

        [JsonIgnore]
        public Tour Tour { get; set; }
    }
}
