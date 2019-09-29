using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandManagerApp.DataEntities
{
    public class Band
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime DateofCreation { get; set; }

        public string Country { get; set; }

        public string PlayGenre { get; set; }

        public int Rate { get; set; }
    }
}
