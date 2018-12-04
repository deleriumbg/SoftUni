using System;
using System.Collections.Generic;
using System.Text;

namespace IRunesWebApp.Models
{
    public class AlbumTrack
    {
        public string AlbumId { get; set; }
        public virtual Album Album { get; set; }

        public string TrackId { get; set; }
        public virtual Track Track { get; set; }
    }
}
