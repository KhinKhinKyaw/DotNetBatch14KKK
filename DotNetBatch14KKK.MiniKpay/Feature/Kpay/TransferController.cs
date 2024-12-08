using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBatch14KKK.MiniKpay.Feature.Kpay
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        public TransferService _service;
        public TransferController()
        {
            _service = new TransferService();
        }

        [HttpPost("{Password}")]
        public IActionResult CreateTransaction([FromBody] TransactionModel requestTransactionModel, int Password)
        {
            var model = _service.CreateTransaction(requestTransactionModel, Password);

            if (!model.IsSuccess)
            {
                BadRequest(model);
            }
            return Ok(model);
        }

        [HttpGet("{MobileNo}")]
        public IActionResult GetTransaction(string MobileNo)
        {
            var model = _service.GetTransaction(MobileNo);
            if (model is null)
            {
                return NotFound("No Data Found");
            }
            return Ok(model);
        }
    }
}

