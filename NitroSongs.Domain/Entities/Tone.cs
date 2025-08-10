using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroSongs.Domain.Entities
{
    public class Tone
    {
        public long Id { get; set; }
        public string Name { get; set; } = default!;
        public ICollection<Song> Songs { get; set; } = [];
        public ICollection<ChordTone> ChordTones { get; set; } = [];
    }
}
