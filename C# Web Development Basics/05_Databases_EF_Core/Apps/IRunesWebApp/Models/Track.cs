using System.Collections.Generic;

namespace IRunesWebApp.Models
{
    public class Track : BaseModel<string>
    {
        public Track()
        {
            this.Albums = new HashSet<AlbumTrack>();
        }

        public string Name { get; set; }

        public string Link { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<AlbumTrack> Albums { get; set; }
    }
}
