using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroSongs.Domain.Entities
{
    public class Chord
    {
        public long Id { get; set; }
        public string Name { get; set; } = default!;
        public string CodeEs { get; set; } = default!;
        public string CodeEn { get; set; } = default!;
        public long ChordTypeId { get; set; } = default!;

        public ChordType ChordType { get; set; } = default!;
        public ICollection<SongChord> SongChords { get; set; } = [];
        public ICollection<ChordTone> ChordTones { get; set; } = [];
        public ICollection<ImageChords> ImageChords { get; set; } = [];
    }
}
