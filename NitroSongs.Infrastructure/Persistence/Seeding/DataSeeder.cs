using Microsoft.EntityFrameworkCore;
using NitroSongs.Domain.Entities;
using NitroSongs.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace NitroSongs.Infrastructure.Persistence.Seeding
{
    public static class DataSeeder
    {
        public static async Task SeedAsync(NitroSongsDbContext context)
        {
            if (!context.Genres.Any())
            {
                var genres = new List<Genre>
                {
                    new() { Name = "Rock" }
                };

                await context.Genres.AddRangeAsync(genres);
                await context.SaveChangesAsync();
            }

            if (!context.Rhythms.Any())
            {
                var rhythms = new List<Rhythm>
                {
                    new() { Name = "4/4" }
                };
                await context.Rhythms.AddRangeAsync(rhythms);
                await context.SaveChangesAsync();
            }

            if (!context.Tones.Any())
            {
                var tones = new List<Tone>
                {
                    new() { Name = "C" },
                    new() { Name = "D" },
                    new() { Name = "E" },
                    new() { Name = "F" },
                    new() { Name = "G" },
                    new() { Name = "A" },
                    new() { Name = "B" }
                };
                await context.Tones.AddRangeAsync(tones);
                await context.SaveChangesAsync();
            }

            if (!context.Authors.Any())
            {
                var artists = new List<Author>
                {
                    new() { Name = "Eric Clapton" }
                };

                await context.Authors.AddRangeAsync(artists);
                await context.SaveChangesAsync();
            }

            if (!context.Songs.Any())
            {
                var songs = new List<Song>
                {
                    new() { 
                        Title = "Tears in Heaven", 
                        GenreId = 1, 
                        Lyrics = "Would it be the same if I saw you in heaven?...",
                        CreatedAt = DateTime.UtcNow,
                        IsPrivate = false,
                        RhythmId = 1,
                        ToneId = 1,
                        AuthorId = 1
                    }
                };

                await context.Songs.AddRangeAsync(songs);
                await context.SaveChangesAsync();
            }
        }
    }
}
