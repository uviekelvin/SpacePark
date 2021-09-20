using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
  public class FriendstEntityConfig : IEntityTypeConfiguration<Friends>
  {
    public void Configure(EntityTypeBuilder<Friends> builder)
    {
      builder.HasKey(x => new { x.ObserverId, x.TargetId });

      builder.HasOne(x => x.Observer).WithMany(x => x.Following)
      .HasForeignKey(x => x.ObserverId)
      .OnDelete(DeleteBehavior.NoAction);
      builder.HasOne(x => x.Target).WithMany(x => x.Followers)
      .HasForeignKey(x => x.TargetId)
      .OnDelete(DeleteBehavior.NoAction);

    }
  }
}
