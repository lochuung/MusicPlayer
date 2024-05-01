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
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            
            var optionsBuilder = new DbContextOptionsBuilder<MusicDbContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("FineMusicDatabase") ?? throw new InvalidOperationException());
            
            return new MusicDbContext(optionsBuilder.Options);
            
        }
    }
}
