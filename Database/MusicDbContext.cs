using System;
using Microsoft.EntityFrameworkCore;
using MusicPlayer.Database.Entity;
using MusicPlayer.Properties;

namespace MusicPlayer.Database
{
    public class MusicDbContext : DbContext
    {
        public MusicDbContext()
        {
        }

        public MusicDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Verify> Verifies { get; set; }
        public DbSet<LikeMusic> LikePlaylists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(Settings.Default.ConnectionString
                                        ?? throw new InvalidOperationException());
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e =>
            {
                e.HasKey(u => u.UserId);
                e.Property(u => u.UserId).UseIdentityColumn();
                e.HasIndex(u => u.Email).IsUnique();
                e.HasIndex(u => u.PhoneNumber).IsUnique();

                e.HasMany(u => u.Verifications)
                    .WithOne(v => v.User)
                    .HasForeignKey(v => v.UserId)
                    .OnDelete(DeleteBehavior.Cascade);

                e.HasMany(u => u.LikePlaylists)
                    .WithOne(v => v.User)
                    .HasForeignKey(v => v.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Verify>(e =>
            {
                e.Property(v => v.VerifyId).UseIdentityColumn();
                e.HasKey(v => v.VerifyId);
                e.HasIndex(v => v.Code).IsUnique();

                e.HasOne(v => v.User)
                    .WithMany(u => u.Verifications)
                    .HasForeignKey(v => v.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<LikeMusic>(e =>
            {
                e.Property(lp => lp.Id).UseIdentityColumn();
                e.HasKey(lp => lp.Id);

                e.HasOne(lp => lp.User)
                    .WithMany(u => u.LikePlaylists)
                    .HasForeignKey(lp => lp.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}