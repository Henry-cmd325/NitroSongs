using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroSongs.Domain.Entities
{
    public class Song
    {
        public long Id { get; set; }
        public string Title { get; set; } = default!;
        public long GenreId { get; set; }
        public Genre Genre { get; set; } = default!;
        public string Lyrics { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsPrivate { get; set; }
        public long RhythmId { get; set; }
        public Rhythm Rhythm { get; set; } = default!;
        public long ToneId { get; set; }
        public Tone Tone { get; set; } = default!;
        public long AuthorId { get; set; }
        public Author Author { get; set; } = default!;
        public ICollection<SongChord> SongChords { get; set; } = [];
        public ICollection<UserSong> UserSongs { get; set; } = [];
    }
}
