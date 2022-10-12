using ClientApi.Dtos;
using ClientApi.Services;
using Microsoft.AspNetCore.Mvc;
using Post = ClientApi.Services.DataModels.Post;

namespace ClientApi.Controllers;

[Route("api/posts")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly IPostService _postService;

    public PostController(IPostService postService) 
        => _postService = postService;

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var posts =  await _postService.GetPosts();

        return Ok(posts);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var post = _postService.GetPostById(id);

        if (post is null)
        {
            return BadRequest();
        }

        return Ok(post);
    }

    [HttpPost()]
    public async Task<IActionResult> Post(PostDto post)
    {
        await _postService.CreatePost(new Post() { 
           
            Title = post.Title, 
            Description = post.Description, 
            Username = post.Username 
        });
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(string id, PostDto post)
    {
        var oldPost = _postService.GetPostById(id);

        if (post is not null)
        {
            if (post.Username == oldPost.Username)
            {
                oldPost.Title = post.Title;
                oldPost.Description = post.Description;
                oldPost.Username = post.Username;
                oldPost.UpdatedAt = DateTime.Now;

                await _postService.Update(oldPost);

                return Ok();
            }
        }

        return BadRequest();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        if (id is not null)
        {
            _postService.Delete(id);

            return Ok();

        }

        return BadRequest();
    }
}
