using DotNetBatch14KKK.SnakeAndLadderGame.Models;
using DotNetBatch14KKK.SnakeAndLadderGame.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace DotNetBatch14KKK.SnakeAndLadderGame.Features;
[Route("api/[controller]")]
[ApiController]
public class SnakeAndLadderController : ControllerBase
{
    public readonly SnakeAndLadderService _Service;
    public SnakeAndLadderController()
    {
        _Service = new SnakeAndLadderService();
    }

    [HttpPost("CreateGameBoard")]
    public IActionResult CreateGameBoard(GameBoardModel RequestGameBoard)
    {
        try
        {
            var model = _Service.CreateGameBoard(RequestGameBoard);
            if (!model.IsSuccess)
            {
                return BadRequest(model);
            }
            return Ok(model);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ResponseModel()
            {
                Message = ex.ToString()
            });
        }
    }

    [HttpPost("CreateGame")]
    public IActionResult CreateGame(List<PlayerModel> RequestPlayerModel)
    {
        try
        {
            var model = _Service.CreateGame(RequestPlayerModel);
            if (!model.IsSuccess)
            {
                return BadRequest(model);
            }
            return Ok(model);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ResponseModel()
            {
                Message = ex.ToString()
            });
        }
    }

    [HttpPost("PlayGame/{PlayerId}")]
    public IActionResult PlayGame(int PlayerId)
    {
        try
        {
            var model = _Service.PlayGame(PlayerId);
            if (!model.IsSuccess)
            {
                return BadRequest(model);
            }
            return Ok(model);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new ResponseModel()
            {
                Message = ex.ToString()
            });
        }

    }
}
