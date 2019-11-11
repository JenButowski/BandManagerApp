using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BandManagerApp.DataEntities
{
    public class Song
    {
        [JsonIgnore]
        public int Id { get; set; }

        public string Name { get; set; }

        public string MusicAuthor { get; set; }

        public string TextAuthor { get; set; }

        public DateTime IssueDate { get; set; }

        public int? BandId { get; set; }

        [JsonIgnore]
        public Band Band { get; set; }
    }
}
