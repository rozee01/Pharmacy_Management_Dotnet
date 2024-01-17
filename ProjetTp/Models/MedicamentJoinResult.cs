using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetTp.Models
{
    [NotMapped]
    public class MedicamentJoinResult
    {
        public Medicament? Medicament { get; set; }
        public Format? Format { get; set; }
        public Fabriquant? Fabriquant { get; set; }
    }
}
