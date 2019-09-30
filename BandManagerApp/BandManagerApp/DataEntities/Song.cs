using System;
using System.Collections.Generic;
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

        public string Band { get; set; }

        public Song(string Name, string MusicAuthor, string TextAuthor, string IssueDate, string Band)
        {
            this.Name = Name;
            this.MusicAuthor = MusicAuthor;
            this.TextAuthor = TextAuthor;
            this.IssueDate = Convert.ToDateTime(IssueDate);
            this.Band = Band;
        }

        public Song()
        { }
    }
}
