using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandManagerApp.DataEntities
{
    public class Band
    {
        [Key]
        public string Name { get; set; }

        public DateTime DateofCreation { get; set; }

        public string Country { get; set; }

        public string PlayGenre { get; set; }

        public int Rate { get; set; }

        public Manager Manager { get; set; }

        public List<Musician> Musicians { get; set; }

        public List<Song> Songs { get; set; }

        public List<Tour> Tours { get; set; }
    }
}
