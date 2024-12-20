using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DotNetBatch14KKK.SnakeAndLadderGame.Models;

[Table("tbl_game")]
public class GameModel
{
    [Key]
    public int? GameID { get; set; }
    public string? GameStatus { get; set; }
    public int CurrentPlayerID { get; set; }
}
