using Microsoft.EntityFrameworkCore;
using NitroSongs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroSongs.Infrastructure.Persistence.Contexts
{
    public interface INitroSongContext
    {
        public DbSet<Chord> Chords { get; }
        public DbSet<ChordTone> ChordTones { get; }
        public DbSet<Genre> Genres { get; }
        public DbSet<ImageChords> ImageChords { get; }
        public DbSet<Rhythm> Rhythms { get; }
        public DbSet<Song> Songs { get; }
        public DbSet<SongChord> SongChords { get; }
        public DbSet<Tone> Tones { get; }
        public DbSet<User> Users { get; }
        public DbSet<UserSong> UserSongs { get; }
        public DbSet<Author> Authors { get; }
        public DbSet<ChordType> ChordTypes { get; }

    }
}
