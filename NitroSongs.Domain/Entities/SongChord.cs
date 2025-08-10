using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroSongs.Domain.Entities
{
    public class SongChord
    {
        public long Id { get; set; }
        public long SongId { get; set; }
        public Song Song { get; set; } = default!;
        public long ChordId { get; set; }
        public Chord Chord { get; set; } = default!;
        public int WordIndex { get; set; }
        public int LetterIndex { get; set; }
        public int PixelMovement { get; set; }
    }
}
