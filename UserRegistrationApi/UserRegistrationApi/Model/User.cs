using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserRegistrationApi.Model
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string UserId { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
    }
}
