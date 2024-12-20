using Azure.Core.GeoJson;
using DotNetBatch14KKK.SnakeAndLadderGame.Database;
using DotNetBatch14KKK.SnakeAndLadderGame.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using System.ClientModel.Primitives;
using System.Numerics;

namespace DotNetBatch14KKK.SnakeAndLadderGame.Services;

public class SnakeAndLadderService
{
    AppDbContext db;
    public SnakeAndLadderService()
    {
        db = new AppDbContext();
    }

    public ResponseModel CreateGameBoard(GameBoardModel RequsetGameBoard)
    {
        db.GameBoards.Add(RequsetGameBoard);
        int result = db.SaveChanges();

        string message = result > 0 ? "Game Board successfully created" : "Game Board creationg fail";
        ResponseModel model = new ResponseModel();
        model.IsSuccess = result > 0;
        model.Message = message;

        return model;
    }

    public ResponseModel CreateGame(List<PlayerModel> RequestPlayerModel)
    {
        int firstPlayerId = 0;
        for (int i = 0; i < RequestPlayerModel.Count; i++)
        {
            var player = RequestPlayerModel[i];
            db.Players.Add(player);
            db.SaveChanges();

            if (i == 0)
            {
                firstPlayerId = (int)player.PlayerID!;
            }
        }
        var game = new GameModel()
        {
            GameStatus = "InProgress",
            CurrentPlayerID = firstPlayerId
        };

        db.Games.Add(game);
        db.SaveChanges();

        foreach (var players in RequestPlayerModel)
        {
            var InitialGameMove = new GameMoveModel()
            {
                GameID = (int)game.GameID!,
                PlayerID = (int)players.PlayerID!,
                FromCell = 1,
                ToCell = 0,
                MoveDate = DateTime.Now

            };

            db.GameMoves.Add(InitialGameMove);
        }

        var result = db.SaveChanges();

        string message = result > 0 ? "Game created successfully." : "Game creation failed.";
        return new ResponseModel
        {
            IsSuccess = result > 0,
            Message = message
        };

    }

    public ResponseModel PlayGame(int PlayerId)
    {
        ResponseModel model = new ResponseModel();
        var PlayerData = new PlayerModel();
        var GameData = new GameModel();
        PlayerData = db.Players.AsNoTracking().Where(x => x.PlayerID == PlayerId).FirstOrDefault();
        if (PlayerData is null)
        {
            model.IsSuccess = false;
            model.Message = "This player doesn't exist";

            return model;
        }
        GameData = db.Games.AsNoTracking().Where(x => x.CurrentPlayerID == PlayerId).FirstOrDefault();
        if (GameData is null)
        {
            model.IsSuccess = false;
            model.Message = "Not your time";

            return model;
        }
        if (GameData.GameStatus == "Completed")
        {
            model.IsSuccess = false;
            model.Message = "This game is already completed.";

            return model;
        }
        int RollDiceNo = RollDice();
        int OldPosition = (int)PlayerData.CurrentPosition!;
        int NewPosition = 0;
        NewPosition = OldPosition + RollDiceNo;
        if (NewPosition > 100)
        {
            NewPosition = 100 - (NewPosition - 100);
        }

        var GameBoardData = db.GameBoards.AsNoTracking().Where(x => x.CellNumber == (int)NewPosition).FirstOrDefault();
        if (GameBoardData.CellType == "LadderBottom")
        {
            NewPosition += (int)GameBoardData.MoveToCell!;
        }
        else if (GameBoardData.CellType == "SnakeHead")
        {
            NewPosition -= (int)GameBoardData.MoveToCell!;
        }

        //var GameBoardData = db.GameBoards.AsNoTracking().ToList();
        //foreach( var GameBoardCellType in GameBoardData)
        //{
        //    if (GameBoardCellType!.CellType == "LadderBottom")
        //    {
        //        NewPosition += (int)GameBoardCellType.MoveToCell!;
        //    }
        //    else if (GameBoardCellType!.CellType == "SnakeHead")
        //    {
        //        NewPosition -= (int)GameBoardCellType.MoveToCell!;
        //    }
        //} 

        var GameMoveModel = new GameMoveModel()
        {
            GameID = (int)GameData.GameID!,
            PlayerID = (int)PlayerData.PlayerID!,
            FromCell = OldPosition,
            ToCell = NewPosition,
            MoveDate = DateTime.Now
        };
        db.GameMoves.Add(GameMoveModel);
        db.SaveChanges();

        PlayerData.CurrentPosition = NewPosition;
        db.Entry(PlayerData).State = EntityState.Modified;
        db.SaveChanges();

        if (NewPosition == 100)
        {
            GameData.GameStatus = "Completed";
            db.Entry(GameData).State = EntityState.Modified;
            db.SaveChanges();

            model.IsSuccess = true;
            model.Message = PlayerId + " is winner.";
            return model;
        }

        var AllPlayer = db.GameMoves.AsNoTracking().Where(gm => gm.GameID == GameData.GameID)
            .Select(gm => gm.PlayerID)
            .Distinct()
            .OrderBy(id => PlayerId).ToList();

        int CurrentIndex = AllPlayer.IndexOf(PlayerId);
        int NextIndex = (CurrentIndex < AllPlayer.Count - 1) ? CurrentIndex + 1 : 0;

        GameData.CurrentPlayerID = AllPlayer[NextIndex];
        db.Entry(GameData).State = EntityState.Modified;
        db.SaveChanges();

        model.IsSuccess = true;
        model.Message = "Player " + PlayerData.PlayerID + " moved successfully.";

        return model;
    }

    private int RollDice()
    {
        Random random = new Random();
        return random.Next(1, 7);
    }
}

