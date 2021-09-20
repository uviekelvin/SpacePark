using System;
using System.Collections.Generic;

namespace Domain.Models
{
  public class Users : BaseEntity
  {
    public string FirstName { get; set; }
    public string SurName { get; set; }
    public string UserName { get; set; }
    private List<PostLikes> _UserPostLikes = new List<PostLikes>();
    public IReadOnlyCollection<PostLikes> UserPostLikes => _UserPostLikes;

    private List<Friends> _FriendsFollowing = new List<Friends>();
    private List<Friends> _FriendFollowers = new List<Friends>();
    public IReadOnlyCollection<Friends> Following => _FriendsFollowing;
    public IReadOnlyCollection<Friends> Followers => _FriendFollowers;
    private List<UserPosts> _userPosts = new List<UserPosts>();
    public IReadOnlyCollection<UserPosts> UserPost => _userPosts;
    public void SharePost(long postId)
    {
      this._userPosts.Add(new UserPosts
      {
        PostId = postId,
        IsSharedPost = true,
        DateCreated = DateTime.Now
      });
    }
  }
}