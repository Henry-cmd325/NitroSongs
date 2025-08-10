using Microsoft.EntityFrameworkCore;
using NitroSongs.Domain.Entities;

namespace NitroSongs.Infrastructure.Persistence.Contexts
{
    public class NitroSongsDbContext : DbContext, INitroSongContext
    {
        public DbSet<Chord> Chords { get; set; } = default!;
        public DbSet<ChordTone> ChordTones { get; set; } = default!;
        public DbSet<Genre> Genres { get; set; } = default!;
        public DbSet<ImageChords> ImageChords { get; set; } = default!;
        public DbSet<Rhythm> Rhythms { get; set; } = default!;
        public DbSet<Song> Songs { get; set; } = default!;
        public DbSet<SongChord> SongChords { get; set; } = default!;
        public DbSet<Tone> Tones { get; set; } = default!;
        public DbSet<User> Users { get; set; } = default!;
        public DbSet<UserSong> UserSongs { get; set; } = default!;

        public DbSet<Author> Authors { get; set; } = default!;

        public NitroSongsDbContext(DbContextOptions<NitroSongsDbContext> options) : base(options)
        {}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(NitroSongsDbContext).Assembly);
        }
    }
}
