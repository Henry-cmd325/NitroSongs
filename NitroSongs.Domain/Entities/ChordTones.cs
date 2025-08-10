using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroSongs.Domain.Entities
{
    public class ChordTone
    {
        public long Id { get; set; }
        public long ChordId { get; set; }
        public Chord Chord { get; set; } = default!;
        public long ToneId { get; set; }
        public Tone Tone { get; set; } = default!;
    }
}
