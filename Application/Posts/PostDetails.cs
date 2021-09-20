


// using System.Threading;
// using System.Threading.Tasks;
// using AutoMapper;
// using MediatR;
// using Microsoft.EntityFrameworkCore;
// using Persistence;

// namespace Application.Posts.Queries{

// public class PostDetails{

// public class Query:IRequest<PostVm>{
//   public long Id {get;set;}
// }

//     public class Handler : IRequestHandler<Query, PostVm>
//     {
//       private readonly DataContext context;

//       public Handler(DataContext context,IMapper mapper)
//       {
//         this.context = context;
//         Mapper = mapper;
//       }

//       public IMapper Mapper { get; }

//       public async Task<PostVm> Handle(Query request, CancellationToken cancellationToken)
//       {
        
//         return this.Mapper.Map<PostVm>(await this.context.Posts.Include(x=>x.User).FirstOrDefaultAsync(x=>x.Id==request.Id));
//       }
//     }
//   }

// }