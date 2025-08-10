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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(u => u.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.Email)
                .HasColumnName("email")
                .IsRequired()
                .HasMaxLength(80);

            builder.Property(u => u.Password)
                .HasColumnName("password")
                .IsRequired()
                .HasMaxLength(255);

            builder.HasMany(u => u.UserSongs)
                .WithOne(us => us.User)
                .HasForeignKey(us => us.UserId);
        }
    }
}
