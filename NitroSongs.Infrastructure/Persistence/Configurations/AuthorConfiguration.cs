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
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("authors");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(a => a.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(100);

            builder.HasMany(a => a.Songs)
                .WithOne(s => s.Author)
                .HasForeignKey(s => s.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
