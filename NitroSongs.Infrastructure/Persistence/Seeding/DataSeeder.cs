using Microsoft.EntityFrameworkCore;
using NitroSongs.Domain.Entities;
using NitroSongs.Infrastructure.Persistence.Contexts;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;
using System.Collections;
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
            // ===== Helpers locales ==========================================
            async Task<Genre> GetOrCreateGenre(string name)
            {
                var e = await context.Genres.FirstOrDefaultAsync(x => x.Name == name);
                if (e is null)
                {
                    e = new Genre { Name = name };
                    await context.Genres.AddAsync(e);
                    await context.SaveChangesAsync();
                }
                return e;
            }

            async Task<Rhythm> GetOrCreateRhythm(string name)
            {
                var e = await context.Rhythms.FirstOrDefaultAsync(x => x.Name == name);
                if (e is null)
                {
                    e = new Rhythm { Name = name };
                    await context.Rhythms.AddAsync(e);
                    await context.SaveChangesAsync();
                }
                return e;
            }

            async Task<Tone> GetOrCreateTone(string name)
            {
                var e = await context.Tones.FirstOrDefaultAsync(x => x.Name == name);
                if (e is null)
                {
                    e = new Tone { Name = name };
                    await context.Tones.AddAsync(e);
                    await context.SaveChangesAsync();
                }
                return e;
            }

            async Task<Author> GetOrCreateAuthor(string name)
            {
                var e = await context.Authors.FirstOrDefaultAsync(x => x.Name == name);
                if (e is null)
                {
                    e = new Author { Name = name };
                    await context.Authors.AddAsync(e);
                    await context.SaveChangesAsync();
                }
                return e;
            }

            async Task<Song> GetOrCreateSong(string title, Genre genre, Rhythm rhythm, Tone tone, Author author, string lyrics, bool isPrivate)
            {
                var e = await context.Songs.FirstOrDefaultAsync(x => x.Title == title && x.AuthorId == author.Id);
                if (e is null)
                {
                    e = new Song
                    {
                        Title = title,
                        GenreId = genre.Id,
                        RhythmId = rhythm.Id,
                        ToneId = tone.Id,
                        AuthorId = author.Id,
                        Lyrics = lyrics,
                        IsPrivate = isPrivate,
                        CreatedAt = DateTime.UtcNow
                    };
                    await context.Songs.AddAsync(e);
                    await context.SaveChangesAsync();
                }
                return e;
            }

            async Task<ChordType> GetOrCreateChordType(string name, int sortOrder)
            {
                var e = await context.ChordTypes.FirstOrDefaultAsync(x => x.Name == name);
                if (e is null)
                {
                    e = new ChordType { Name = name, SortOrder = sortOrder };
                    await context.ChordTypes.AddAsync(e);
                    await context.SaveChangesAsync();
                }
                return e;
            }

            async Task<Chord> GetOrCreateChord(string name, string codeEs, string codeEn, ChordType type)
            {
                // Asumimos CodeEn como único; si no, combínalo con Type o Name
                var e = await context.Chords.FirstOrDefaultAsync(x => x.CodeEn == codeEn);
                if (e is null)
                {
                    e = new Chord
                    {
                        Name = name,
                        CodeEs = codeEs,
                        CodeEn = codeEn,
                        ChordTypeId = type.Id,     // o ChordType = type;
                        ChordType = type
                    };
                    await context.Chords.AddAsync(e);
                    await context.SaveChangesAsync();
                }
                return e;
            }

            async Task EnsureImageChord(Chord chord, string url, int sortOrder = 1)
            {
                var exists = await context.ImageChords
                    .AnyAsync(ic => ic.ChordId == chord.Id && ic.SortOrder == sortOrder);
                if (!exists)
                {
                    await context.ImageChords.AddAsync(new ImageChords
                    {
                        ChordId = chord.Id,
                        Url = url,
                        SortOrder = sortOrder
                    });
                    await context.SaveChangesAsync();
                }
            }

            // ===== 1) Semillas transversales ================================
            var rock = await GetOrCreateGenre("Rock");
            var rhythm44 = await GetOrCreateRhythm("4/4");

            var toneNames = new[] { "C", "D", "E", "F", "G", "A", "B", "C#", "D#", "F#", "G#", "A#" };
            var tones = new List<Tone>();
            foreach (var t in toneNames)
                tones.Add(await GetOrCreateTone(t));

            var clapton = await GetOrCreateAuthor("Eric Clapton");

            await GetOrCreateSong(
                title: "Tears in Heaven",
                genre: rock,
                rhythm: rhythm44,
                tone: tones.First(x => x.Name == "C"),
                author: clapton,
                lyrics: "Would it be the same if I saw you in heaven?...",
                isPrivate: false
            );

            // ===== 2) Tipos de acordes =====================================
            var mayores = await GetOrCreateChordType("Mayores", 1);
            var menores = await GetOrCreateChordType("Menores", 2);
            var septimas = await GetOrCreateChordType("Séptimas", 3);
            var septimasMenores = await GetOrCreateChordType("Séptimas menores", 5);

            // ===== 3) Acordes por tipo =====================================
            // Mayores
            var c = await GetOrCreateChord("Do Mayor", "Do", "C", mayores);
            var d = await GetOrCreateChord("Re Mayor", "Re", "D", mayores);
            var e = await GetOrCreateChord("Mi Mayor", "Mi", "E", mayores);
            var f = await GetOrCreateChord("Fa Mayor", "Fa", "F", mayores);
            var g = await GetOrCreateChord("Sol Mayor", "Sol", "G", mayores);
            var a = await GetOrCreateChord("La Mayor", "La", "A", mayores);
            var b = await GetOrCreateChord("Si Mayor", "Si", "B", mayores);

            // Menores
            var cm = await GetOrCreateChord("Do menor", "Do m", "Cm", menores);
            var dm = await GetOrCreateChord("Re menor", "Re m", "Dm", menores);
            var em = await GetOrCreateChord("Mi menor", "Mi m", "Em", menores);
            var fm = await GetOrCreateChord("Fa menor", "Fa m", "Fm", menores);
            var gm = await GetOrCreateChord("Sol menor", "Sol m", "Gm", menores);
            var am = await GetOrCreateChord("La menor", "La m", "Am", menores);
            var bm = await GetOrCreateChord("Si menor", "Si m", "Bm", menores);

            // Séptimas (dominantes)
            var c7 = await GetOrCreateChord("Do Séptima", "Do7", "C7", septimas);
            var d7 = await GetOrCreateChord("Re Séptima", "Re7", "D7", septimas);
            var e7 = await GetOrCreateChord("Mi Séptima", "Mi7", "E7", septimas);
            var f7 = await GetOrCreateChord("Fa Séptima", "Fa7", "F7", septimas);
            var g7 = await GetOrCreateChord("Sol Séptima", "Sol7", "G7", septimas);
            var a7 = await GetOrCreateChord("La Séptima", "La7", "A7", septimas);
            var b7 = await GetOrCreateChord("Si Séptima", "Si7", "B7", septimas);

            // (Opcional) Séptimas menores típicas (m7)
            // Si aún no lo usas, puedes omitirlos o dejarlos listos:
            // var cm7 = await GetOrCreateChord("Do menor 7", "Dom7", "Cm7", septimasMenores);
            // ...

            // ===== 4) Imágenes por acorde (ejemplo: SortOrder=1) ============
            // Pon las URLs reales de tus diagramas si ya las tienes.
            string Img(string codeEn) => $"/img/chords/{codeEn}.png"; // helper simple

            var all = new[]
            {
                c, d, e, f, g, a, b, cm, dm, em, fm, gm, am, bm, c7, d7, e7, f7, g7, a7, b7
            };

            foreach (var ch in all)
            {
                await EnsureImageChord(ch, Img(ch.CodeEn), sortOrder: 1);
            }
        }
    }
}
    

