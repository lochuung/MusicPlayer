using Microsoft.EntityFrameworkCore;
using MusicPlayer.Database.Entity;

namespace MusicPlayer.Database
{
    public class MusicDbContext : DbContext
    {
        protected MusicDbContext()
        {
        }

        public MusicDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e =>
            {
                e.HasKey(u => u.UserId);
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
                e.HasKey(v => v.VerifyId);
                e.HasIndex(v => v.Code).IsUnique();
                
                e.HasOne(v => v.User)
                    .WithMany(u => u.Verifications)
                    .HasForeignKey(v => v.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            
            modelBuilder.Entity<LikePlaylist>(e =>
            {
                e.HasKey(lp => lp.Id);
                e.HasIndex(lp => lp.MusicCode).IsUnique();
                
                e.HasOne(lp => lp.User)
                    .WithMany(u => u.LikePlaylists)
                    .HasForeignKey(lp => lp.UserId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
            
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Verify> Verifies { get; set; }
        public DbSet<LikePlaylist> LikePlaylists { get; set; }
    }
}