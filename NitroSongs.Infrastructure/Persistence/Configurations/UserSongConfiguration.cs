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
    public class UserSongConfiguration : IEntityTypeConfiguration<UserSong>
    {
        public void Configure(EntityTypeBuilder<UserSong> builder)
        {
            builder.ToTable("user_songs");

            builder.HasKey(us => us.Id);

            builder.Property(us => us.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(us => us.UserId)
                .HasColumnName("user_id")
                .IsRequired();

            builder.Property(us => us.SongId)
                .HasColumnName("song_id")
                .IsRequired();
        }
    }
}
