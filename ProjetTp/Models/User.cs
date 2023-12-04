using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetTp.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public string? UserEmail { get; set; }
        public string? Password { get; set; }
        //1 for admin, 2 for pharmacist, 3 for doctor
        public int Role {  get; set; }

    }
}
