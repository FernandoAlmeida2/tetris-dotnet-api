using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace tetris_api.Models
{
    [Table("results")]
    public class ResultModel
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int score { get; set; }
        public int speed { get; set; }
    }
}