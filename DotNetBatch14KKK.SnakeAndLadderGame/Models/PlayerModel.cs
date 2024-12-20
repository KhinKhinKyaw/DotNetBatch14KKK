using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace DotNetBatch14KKK.SnakeAndLadderGame.Models;

[Table("tbl_player")]
public class PlayerModel
{
    [Key]
    public int? PlayerID { get; set; }
    public string? PlayerName { get; set; }
    public int? CurrentPosition { get; set; }

}
