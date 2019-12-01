using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandManagerApp.DataEntities
{
    public class Tour
    {
        [Key]
        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public Band Band { get; set; }

        public List<Concert> Concerts { get; set; }
    }
}
