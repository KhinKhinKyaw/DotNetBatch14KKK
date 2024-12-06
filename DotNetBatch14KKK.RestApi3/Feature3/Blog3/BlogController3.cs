using System.Reflection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBatch14KKK.RestApi3.Feature3.Blog3
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController3 : ControllerBase
    {
        private readonly BlogService3 _blogService;
        public BlogController3()
        {
            _blogService = new BlogService3();
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
        public IActionResult CreateBlog([FromBody] BlogModel3 requestModel)
        {
            var model = _blogService.Create(requestModel);
            if (!model.IsSuccess)
            {
                return BadRequest(model);
            }
            return Ok(model);
        }

        [HttpPut]
        public IActionResult UpdateBlog(string id, BlogModel3 requestModel)
        {
            requestModel.BlogId = id;

            var model = _blogService.UpInsert(requestModel);
            if (!model.IsSuccess)
            {
                return BadRequest(model);
            }

            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(string id, BlogModel3 requestModel)
        {
            requestModel.BlogId = id;

            var model = _blogService.Update(requestModel);
            if (!model.IsSuccess)
            {
                return BadRequest(model);
            }
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var model = _blogService.Delete(id);
            if (!model.IsSuccess) return NotFound(model);

            return Ok(model);
        }
    }
}
