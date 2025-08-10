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
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("genres");

            builder.HasKey(g => g.Id);

            builder.Property(g => g.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(g => g.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(g => g.Songs)
                .WithOne(s => s.Genre)
                .HasForeignKey(s => s.GenreId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
