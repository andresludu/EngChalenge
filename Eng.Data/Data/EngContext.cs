using Eng.Domain.Entity;
using Eng.Data.Data.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Eng.Data
{
  public class EngContext : DbContext
  {
    private readonly IConfiguration _configuration;

    public EngContext() { }

    public EngContext(IConfiguration configuration, DbContextOptions<EngContext> options)
      : base(options)
    {
      _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      if (_configuration != null)
      {
        optionsBuilder.UseSqlServer(_configuration.GetConnectionString("default"));
      }
    }

    public DbSet<User> User { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      modelBuilder.ApplyConfiguration(new UserConfiguration());

      base.OnModelCreating(modelBuilder);
    }

  }
}
