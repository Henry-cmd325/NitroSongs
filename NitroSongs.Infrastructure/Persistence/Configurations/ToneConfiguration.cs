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
    public class ToneConfiguration : IEntityTypeConfiguration<Tone>
    {
        public void Configure(EntityTypeBuilder<Tone> builder)
        {
            builder.ToTable("tones");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(t => t.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(t => t.Songs)
                .WithOne(s => s.Tone)
                .HasForeignKey(s => s.ToneId);

            builder.HasMany(t => t.ChordTones)
                .WithOne(ct => ct.Tone)
                .HasForeignKey(ct => ct.ToneId);
        }
    }
}
