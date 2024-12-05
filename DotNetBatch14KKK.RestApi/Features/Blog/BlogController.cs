using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBatch14KKK.RestApi.Features.Blog;


[Route("api/[controller]")]
[ApiController]
public class BlogController: ControllerBase
{
    private readonly BlogServices _blogService;
    public BlogController()
    {
        _blogService = new BlogServices();
    }

    [HttpGet]
    public IActionResult GetBlogs()
    {
        var model = _blogService.GetBlogs();
        return Ok(model);
    }

    [HttpGet("{id}")]
    public IActionResult GetBlog(string id)
    {
        var model = _blogService.GetBlog(id);
        if (model is null)
            return NotFound("No data found.");

        return Ok(model);
    }

    [HttpPost]
    public IActionResult CreateBlog([FromBody] BlogModel requestModel)
    {
        var model = _blogService.CreateBlog(requestModel);
        if (!model.IsSuccess)
        {
            return BadRequest(model);
        }
        return Ok(model);
    }

    [HttpPut]
    public IActionResult UpdateBlog(string id, BlogModel requestModel)
    {
        requestModel.BlogId = id;

        var model = _blogService.UpInsertBlog(requestModel);
        if (!model.IsSuccess)
        {
            return BadRequest(model);
        }

        return Ok();
    }

    [HttpPatch("{id}")]
    public IActionResult PatchBlog(string id, BlogModel requestModel)
    {
        requestModel.BlogId = id;

        var model = _blogService.UpdateBlog(requestModel);
        if (!model.IsSuccess)
        {
            return BadRequest(model);
        }
        return Ok(model);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(string id)
    {
        var model = _blogService.DeleteBlog(id);
        if (!model.IsSuccess) return NotFound(model);

        return Ok(model);
    }
}