using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MusicPlayer.Properties;

namespace MusicPlayer.Database
{
    internal class MusicDbContextFactory : IDesignTimeDbContextFactory<MusicDbContext>
    {
        public MusicDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MusicDbContext>();
            optionsBuilder.UseSqlServer(Settings.Default.ConnectionString ?? throw new InvalidOperationException());

            return new MusicDbContext(optionsBuilder.Options);
        }
    }
}