using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class UserPostLikesEntityConfig : IEntityTypeConfiguration<PostLikes>
    {
        public void Configure(EntityTypeBuilder<PostLikes> builder)
        {
            builder.HasKey(x => new { x.PostId, x.UserId });
            
            builder.HasOne(x=>x.User).WithMany(x=>x.UserPostLikes)
            .OnDelete(DeleteBehavior.Restrict)
            .HasForeignKey(x=>x.UserId);

           builder.HasOne(x=>x.Post).WithMany(x=>x.UserPostLikes)
            .OnDelete(DeleteBehavior.Restrict)
            .HasForeignKey(x=>x.PostId);
        }
    }
}
