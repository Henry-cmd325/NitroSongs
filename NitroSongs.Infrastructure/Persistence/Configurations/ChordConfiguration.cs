using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NitroSongs.Domain.Entities;

namespace NitroSongs.Infrastructure.Persistence.Configurations
{
    public class ChordConfiguration : IEntityTypeConfiguration<Chord>
    {
        public void Configure(EntityTypeBuilder<Chord> builder)
        {
            builder.ToTable("chords");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(c => c.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.CodeEn)
                .HasColumnName("code_en")
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(c => c.CodeEs)
                .HasColumnName("code_es")
                .IsRequired()
                .HasMaxLength(10); 

            builder.Property(c => c.ChordTypeId)
                .HasColumnName("chord_type_id")
                .IsRequired();

            builder.HasMany(c => c.SongChords) 
                .WithOne(sc => sc.Chord)
                .HasForeignKey(sc => sc.ChordId);

            builder.HasMany(c => c.ChordTones)
                .WithOne(ct => ct.Chord)
                .HasForeignKey(ct => ct.ChordId);

            builder.HasMany(c => c.ImageChords)
                .WithOne(ic => ic.Chord)
                .HasForeignKey(ic => ic.ChordId);
        }
    }
}
