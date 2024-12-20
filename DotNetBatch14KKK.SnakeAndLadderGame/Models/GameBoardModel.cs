using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DotNetBatch14KKK.SnakeAndLadderGame.Models;

[Table("tbl_gameBoard")]
public class GameBoardModel
{
    
   
        [Key]
        public int? BoardID { get; set; }
        public int CellNumber { get; set; }
        public string CellType { get; set; }
        public int? MoveToCell { get; set; }

    



}
