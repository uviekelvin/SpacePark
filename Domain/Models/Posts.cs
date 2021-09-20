using System;
using System.Collections.Generic;

namespace Domain.Models
{
  public class Posts : BaseEntity<Guid>
  {

    public string Post { get; set; }
    public int TotalLikes { get; set; }
    public Users User { get; set; }
    public long UserId { get; set; }
    private List<PostLikes> _UserPostLikes = new List<PostLikes>();
    private List<UserPosts> _UserPosts = new List<UserPosts>();
    public IReadOnlyCollection<PostLikes> UserPostLikes => _UserPostLikes;
    public IReadOnlyCollection<UserPosts> UserPosts => _UserPosts;
    public Posts()
    {
      this.Id = Guid.NewGuid();
    }
    public void AddUserPost()
    {
      this._UserPosts.Add(new Models.UserPosts
      {
        DateCreated = DateTime.Now,
        IsSharedPost = false,
        UserId = this.UserId
      });
    }
  }
}