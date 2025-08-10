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
    public class ChordTonesConfiguration : IEntityTypeConfiguration<ChordTone>
    {
        public void Configure(EntityTypeBuilder<ChordTone> builder)
        {
            builder.ToTable("chord_tones");

            builder.HasKey(ct => ct.Id);

            builder.Property(ct => ct.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(ct => ct.ChordId)
                .HasColumnName("chord_id")
                .IsRequired();

            builder.Property(ct => ct.ToneId)
                .HasColumnName("tone_id")
                .IsRequired();
        }
    }
}
