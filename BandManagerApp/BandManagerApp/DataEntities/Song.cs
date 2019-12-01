using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BandManagerApp.DataEntities
{
    public class Song
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string MusicAuthor { get; set; }

        public string TextAuthor { get; set; }

        public DateTime IssueDate { get; set; }

        [ForeignKey("Band")]
        public string BandName { get; set; }

        public Band Band { get; set; }
    }
}
