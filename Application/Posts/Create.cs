
using System.Threading;
using System.Threading.Tasks;
using Application.Posts.ViewModels;
using MediatR;
using Persistence;

namespace Application.Posts
{

  public class Create
  {
    public class Command : IRequest
    {
      public CreatePostVm Post { get; set; }
    }
    public class Handler : IRequestHandler<Command>
    {
      private readonly DataContext context;

      public Handler(DataContext context)
      {
        this.context = context;
      }
      public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
      {

        var post = new Domain.Models.Posts
        {
          UserId = request.Post.UserId,
          Post = request.Post.Post,
        };
        post.AddUserPost();
        this.context.Posts.Add(post);
        await this.context.SaveChangesAsync();
        return Unit.Value;
      }
    }
  }

}
