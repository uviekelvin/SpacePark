

using AutoMapper;
using Domain.Models;

public class PostMapper : Profile
{
  public PostMapper()
  {
    CreateMap<UserPosts, PostVm>()
    .ForMember(x => x.Post, opt => opt.MapFrom(x => x.Post.Post))
    .ForMember(x => x.Id, opt => opt.MapFrom(x => x.PostId))
    .ForMember(x => x.PostedBy,
    opt => opt.MapFrom(x => new PostedByVm
    {
      FirstName = x.User.FirstName,
      SurName = x.User.SurName,
      UserName = x.User.UserName
    }))
    .ForMember(x => x.TotalLikes, opt => opt.MapFrom(a => a.Post.UserPostLikes.Count))
    .ForMember(x => x.IsSharedPost, opt => opt.MapFrom(x => x.IsSharedPost))
    .ForMember(x => x.PostedDate, opt => opt.MapFrom(x => x.DateCreated));
  }
}

