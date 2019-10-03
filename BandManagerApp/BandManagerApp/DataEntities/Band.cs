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

        public List<Musician> Musicians { get; set; } = new List<Musician>();

        public int Rate { get; set; }

        public Band(string Name, string DateofCreation, string Country, string PlayGenre, int Rate)
        {
            this.Name = Name;
            this.DateofCreation = Convert.ToDateTime(DateofCreation);
            this.Country = Country;
            this.PlayGenre = PlayGenre;
            this.Rate = Rate;
        }

        public Band()
        { }
    }
}
