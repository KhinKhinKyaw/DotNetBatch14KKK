using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBatch14KKK.MiniKpay.Feature.Kpay
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositController : ControllerBase
    {
        public DepositService _service;
        public DepositController()
        {
            _service = new DepositService();
        }

        [HttpPatch]
        public IActionResult PatchBalance(string mobileNo, decimal amount)
        {
            var model = _service.Deposit(mobileNo, amount);

            if (!model.IsSuccess)
            {
                BadRequest(model);
            }
            return Ok(model);
        }
    }
}