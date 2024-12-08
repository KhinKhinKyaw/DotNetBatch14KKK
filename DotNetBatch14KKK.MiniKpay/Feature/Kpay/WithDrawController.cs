using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBatch14KKK.MiniKpay.Feature.Kpay
{
    [Route("api/[controller]")]
    [ApiController]
    public class WithDrawController : ControllerBase
    {
        public WithDrawService _service;
        public WithDrawController()
        {
            _service = new WithDrawService();
        }

        [HttpPost]
        public IActionResult WidthDraw(string mobileNo, decimal amount, int password)
        {
            var model = _service.WidthDraw(mobileNo, amount, password);

            if (!model.IsSuccess)
            {
                BadRequest(model);
            }
            return Ok(model);
        }
    }
}

