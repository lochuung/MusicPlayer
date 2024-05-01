using Microsoft.EntityFrameworkCore.Design;
using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MusicPlayer.Database
{
    internal class MusicDbContextFactory : IDesignTimeDbContextFactory<MusicDbContext>
    {
        public MusicDbContext CreateDbContext(string[] args)
        {
            
            var optionsBuilder = new DbContextOptionsBuilder<MusicDbContext>();
            optionsBuilder.UseSqlServer(Properties.Settings.Default.ConnectionString ?? throw new InvalidOperationException());
            
            return new MusicDbContext(optionsBuilder.Options);
        }
    }
}
