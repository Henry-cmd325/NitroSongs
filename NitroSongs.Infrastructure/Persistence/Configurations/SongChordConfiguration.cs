using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NitroSongs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroSongs.Infrastructure.Persistence.Configurations
{
    public class SongChordConfiguration : IEntityTypeConfiguration<SongChord>
    {
        public void Configure(EntityTypeBuilder<SongChord> builder)
        {
            builder.ToTable("song_chords");

            builder.HasKey(sc => sc.Id);

            builder.Property(sc => sc.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(sc => sc.SongId)
                .HasColumnName("song_id")
                .IsRequired();

            builder.Property(sc => sc.ChordId)
                .HasColumnName("chord_id")
                .IsRequired();

            builder.Property(sc => sc.WordIndex)
                .HasColumnName("word_index")
                .IsRequired();

            builder.Property(sc => sc.LetterIndex)
                .HasColumnName("letter_index")
                .IsRequired();

            builder.Property(sc => sc.PixelMovement)
                .HasColumnName("pixel_movement")
                .IsRequired();
        }
    }
}
