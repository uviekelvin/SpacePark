using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Posts
{
    public class List
    {
        public class Query : IRequest<IEnumerable<PostVm>> { }
        public class Handler : IRequestHandler<Query, IEnumerable<PostVm>>
        {
            private readonly DataContext _context;
            private readonly IMapper _mapper;

            public Handler(DataContext context, IMapper mapper)
            {
                this._context = context;
                this._mapper = mapper;
            }

            public async Task<IEnumerable<PostVm>> Handle(Query request, CancellationToken cancellationToken)
            {
                var Friends = this._context.Friends.Where(x => x.TargetId == 1 && x.IsAccepted)
                .Select(a => a.ObserverId);
                var posts = await
                this._context.UserPosts
                .Include(x => x.Post)
                   .ThenInclude(x => x.User)
                   .ThenInclude(x => x.Followers)
                .Include(x => x.Post.UserPostLikes)
                .Where(x => Friends.Any(f => f == x.UserId) || x.UserId == 1)
                .OrderByDescending(x => x.DateCreated)
                .ThenByDescending(x => !x.IsSharedPost)
                .ToListAsync();
                return _mapper.Map<IEnumerable<PostVm>>(posts);
            }
        }
    }
}