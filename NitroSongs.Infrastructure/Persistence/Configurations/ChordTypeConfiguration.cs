using Microsoft.EntityFrameworkCore;
using NitroSongs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NitroSongs.Infrastructure.Persistence.Configurations
{
    public class ChordTypeConfiguration : IEntityTypeConfiguration<ChordType>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<ChordType> builder)
        {
            builder.ToTable("chord_types");

            builder.HasKey(ct => ct.Id);
            builder.Property(ct => ct.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(ct => ct.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(ct => ct.SortOrder)
                .HasColumnName("sort_order")
                .IsRequired();

            builder.HasMany(ct => ct.Chords)
                .WithOne(c => c.ChordType)
                .HasForeignKey(c => c.ChordTypeId);
        }
    }
}
