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
    public class ImageChordsConfiguration : IEntityTypeConfiguration<ImageChords>
    {
        public void Configure(EntityTypeBuilder<ImageChords> builder)
        {
            builder.ToTable("image_chords");

            builder.HasKey(ic => ic.Id);

            builder.Property(ic => ic.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(ic => ic.Url)
                .HasColumnName("url")
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(ic => ic.ChordId)
                .HasColumnName("chord_id")
                .IsRequired();

            builder.Property(ic => ic.SortOrder)
                .HasColumnName("sort_order")
                .IsRequired();
        }
    }
}
