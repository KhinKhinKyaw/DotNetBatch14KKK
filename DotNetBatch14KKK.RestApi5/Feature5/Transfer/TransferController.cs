using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetBatch14KKK.RestApi5.Feature5.Transfer
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        public ITransferService transferService;

        public TransferController()
        {
            transferService = new TransferEFCoreService();
        }

        [HttpPost]
        public IActionResult PostUser([FromBody] UserModel requestUserModel)
        {
            var model = transferService.CreateUser(requestUserModel);

            if (!model.IsSuccess)
            {
                BadRequest(model);
            }
            return Ok(model);
        }

        [HttpPost("{Password}")]
        public IActionResult PostTransfer([FromBody] TransactionModel requestTransactionModel, int Password)
        {
            var model = transferService.CreateTransaction(requestTransactionModel, Password);

            if (!model.IsSuccess)
            {
                BadRequest(model);
            }
            return Ok(model);
        }

        [HttpGet("{MobileNo}")]
        public IActionResult Get(string MobileNo)
        {
            var model = transferService.GetTransaction(MobileNo);
            if (model is null)
            {
                return NotFound("No Data Found");
            }
            return Ok(model);
        }
    }
}
