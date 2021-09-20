


using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Posts;
using Application.Posts.ViewModels;
using Microsoft.AspNetCore.Mvc;
using static Application.Posts.Create;

public class PostsController : BaseController
{

  [HttpGet]
  [ProducesResponseType(typeof(IEnumerable<PostVm>), 200)]
  public async Task<IActionResult> GetAll()
  {

    return Ok(await this.Mediator.Send(new List.Query()));
  }

  [HttpPost]
  public async Task<IActionResult> Create([FromBody] CreatePostVm create)
  {
    return Ok(await this.Mediator.Send(new Create.Command { Post = create }));
  }
  [HttpPost]
  public async Task<IActionResult> Share([FromBody] SharePostVm sharePostVm)
  {
    return Ok(await this.Mediator.Send(new Share.Command { PostId = sharePostVm.Id, UserId = sharePostVm.UserId }));
  }
}