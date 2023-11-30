using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetTp.Models
{
    [Table("Format")]
    public class Format
    {
        [Key]
        public int Id { get; set; }
        
        public string? Name { get; set; }
    }
}
