namespace NitroSongs.Common.Dtos
{
    public class SongDto
    {
        public long Id { get; set; }
        public string Title { get; set; } = default!;
        public long GenreId { get; set; }
        public string Genre { get; set; } = default!;
        public string Lyrics { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsPrivate { get; set; }
        public long RhythmId { get; set; }
        public string Rhythm { get; set; } = default!;
        public long ToneId { get; set; }
        public string Tone { get; set; } = default!;
        public long AuthorId { get; set; }
        public string Author { get; set; } = default!;
    }
}
