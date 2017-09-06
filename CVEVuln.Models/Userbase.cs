using CVEVuln.Extensions;
using System.ComponentModel.DataAnnotations;
namespace CVEVuln.Models
{
    public class Userbase
    {
        public int UserId { get; set; }

        [Required]
        [Map("UserName")]
        public string Name { get; set; }

        public string Email { get; set; }

        // ToDo: remove this property.
        [Required]
        public string Password { get; set; }
    }
}
