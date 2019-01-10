using System.Collections.Generic;

namespace IRunesWebApp.Models
{
    public class Album : BaseModel<string>
    {
        public Album()
        {
            this.Tracks = new HashSet<AlbumTrack>();
        }

        public string Name { get; set; }

        public string Cover { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<AlbumTrack> Tracks { get; set; }
    }
}
