using System;

namespace Domain.Models
{
  public class PostLikes
  {
    public Guid PostId { get; set; }
    public long UserId { get; set; }
    public Posts Post { get; set; }
    public Users User { get; set; }
    public DateTime DateLiked { get; set; }
  }
}