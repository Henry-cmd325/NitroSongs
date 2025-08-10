using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroSongs.Domain.Entities
{
    public class ImageChords
    {
        public long Id { get; set; }
        public string Url { get; set; } = string.Empty;
        public long ChordId { get; set; }
        public int SortOrder { get; set; }
        public Chord Chord { get; set; } = default!;
    }
}
