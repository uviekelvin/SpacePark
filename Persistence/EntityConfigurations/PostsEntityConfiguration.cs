using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
  public class PostsEntityConfiguration : IEntityTypeConfiguration<Posts>
  {
    public void Configure(EntityTypeBuilder<Posts> builder)
    {
      builder.Property(x => x.Post);
      builder.Property(x => x.Id).HasMaxLength(40);

    }
  }
}
