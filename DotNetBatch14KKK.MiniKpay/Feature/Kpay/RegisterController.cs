using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBatch14KKK.MiniKpay.Feature.Kpay
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        public RegisterService _service;
        public RegisterController()
        {
            _service = new RegisterService();
        }
        [HttpPost]
        public IActionResult CreateUser([FromBody] UserModel requestUserModel)
        {
            var model = _service.CreateUser(requestUserModel);

            if (!model.IsSuccess)
            {
                BadRequest(model);
            }
            return Ok(model);
        }
    }
}

