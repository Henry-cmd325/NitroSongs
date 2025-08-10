using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NitroSongs.Domain.Entities;
namespace NitroSongs.Infrastructure.Persistence.Configurations
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.ToTable("songs");

            builder.HasKey(s => s.Id);

            builder.Property(s => s.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(s => s.Title)
                .HasColumnName("title")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(s => s.GenreId)
                .HasColumnName("genre_id")
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(s => s.Lyrics)
                .HasColumnName("lyrics")
                .HasColumnType("text")
                .IsRequired();

            builder.Property(s => s.CreatedAt)
                .HasColumnName("created_at")
                .HasColumnType("timestamp with time zone")
                .IsRequired();

            builder.Property(s => s.UpdatedAt)
                .HasColumnName("updated_at")
                .HasColumnType("timestamp with time zone");

            builder.Property(s => s.IsPrivate)
                .HasColumnName("is_private");

            builder.Property(s => s.RhythmId)
                .HasColumnName("rhythm_id")
                .IsRequired();

            builder.Property(s => s.ToneId)
                .HasColumnName("tone_id")
                .IsRequired();

            builder.Property(s => s.AuthorId)
                .HasColumnName("author_id")
                .IsRequired();

            builder.HasMany(s => s.SongChords)
                .WithOne(sc => sc.Song)
                .HasForeignKey(sc => sc.SongId);

            builder.HasMany(s => s.UserSongs)
                .WithOne(us => us.Song)
                .HasForeignKey(us => us.SongId);
        }
    }
}
