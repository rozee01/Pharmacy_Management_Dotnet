using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetTp.Models
{
    [Table("Medicament")]
    public class Medicament
    {
        [Key]
        public Guid Id { get; set; }
        public string? Name { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }
        [ForeignKey("Fabriquant")]
        public int FabriquantId { get; set; }
        [ForeignKey("Format")]
        public int FormatId { get; set; }


    }
}
