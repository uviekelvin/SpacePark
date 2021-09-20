using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class UserPostEntityConfig : IEntityTypeConfiguration<UserPosts>
    {
        public void Configure(EntityTypeBuilder<UserPosts> builder)
        {
            builder.HasKey(x => new { x.PostId, x.UserId });

            builder.HasOne(x=>x.User).WithMany(x=>x.UserPost)
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
