// See https://aka.ms/new-console-template for more information
using DotNetBatch14KKK.ConsoleAppSnakeAndLadder;

Console.WriteLine("Hello, World!");

Console.WriteLine("Hello, World!");


RefitClientService _client = new RefitClientService();

//List<PlayerModel> players = new List<PlayerModel>()
//{
//    new PlayerModel
//    {
//        PlayerName = "AA",
//        CurrentPosition = 1
//    },
//    new PlayerModel
//    {
//        PlayerName = "BB",
//        CurrentPosition = 1
//    },
//    new PlayerModel
//    {
//        PlayerName = "CC",
//        CurrentPosition = 1
//    }
//};

//var model = await _client.CreateGame(players);
//Console.WriteLine(model.IsSuccess);
//Console.WriteLine(model.Message);
//Console.ReadLine();

var playerResponse = await _client.PlayGame(24);
Console.WriteLine(playerResponse.IsSuccess);
Console.WriteLine(playerResponse.Message);
Console.ReadLine();