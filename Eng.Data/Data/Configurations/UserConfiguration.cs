using Eng.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eng.Data.Data.Configurations
{
  internal class UserConfiguration : IEntityTypeConfiguration<User>
  {
    public void Configure(EntityTypeBuilder<User> builder)
    {
      builder.HasKey(e => e.Id);
      builder.Property(e => e.Id).ValueGeneratedOnAdd();
    }
  }
}
