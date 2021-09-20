
using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Posts
{

  public class Share
  {
    public class Command : IRequest
    {
      public Guid PostId { get; set; }
      public long UserId { get; set; }
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
        var user = await this.context.Users.FirstOrDefaultAsync(x => x.Id == request.UserId);
        if (user == null) throw new System.Exception("User Not Found");
        user.SharePost(request.PostId);
        await this.context.SaveChangesAsync();
        return Unit.Value;
      }
    }
  }

}
