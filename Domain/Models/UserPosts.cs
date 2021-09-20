using System;
namespace Domain.Models
{
  public class UserPosts
  {
    public Guid PostId { get; set; }
    public long UserId { get; set; }
    public Users User { get; set; }
    public Posts Post { get; set; }
    public bool IsSharedPost { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
  }
}