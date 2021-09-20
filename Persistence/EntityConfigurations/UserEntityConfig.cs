using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations
{
    public class UserEntityConfig : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.Property(x => x.FirstName).HasMaxLength(500);
            builder.Property(x => x.UserName).HasMaxLength(100);
            builder.Property(x => x.SurName).HasMaxLength(500);
            builder.HasMany(x=>x.UserPostLikes).WithOne(x=>x.User)
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
