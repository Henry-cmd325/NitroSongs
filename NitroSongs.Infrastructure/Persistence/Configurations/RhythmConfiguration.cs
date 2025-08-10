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
    public class RhythmConfiguration : IEntityTypeConfiguration<Rhythm>
    {
        public void Configure(EntityTypeBuilder<Rhythm> builder)
        {
            builder.ToTable("rhythms");

            builder.HasKey(r => r.Id);
            
            builder.Property(r => r.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(r => r.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(r => r.ImgUrl)
                .HasColumnName("img_url")
                .IsRequired()
                .HasMaxLength(255);

            builder.HasMany(r => r.Songs)
                .WithOne(s => s.Rhythm) 
                .HasForeignKey(s => s.RhythmId) 
                .OnDelete(DeleteBehavior.Restrict); 
        }
    }
}
