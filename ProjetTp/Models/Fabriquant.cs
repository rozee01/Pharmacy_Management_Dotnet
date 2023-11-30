using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetTp.Models
{
    [Table("Fabriquant")]
    public class Fabriquant
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public long PhoneNumber { get; set; }

    }
}
