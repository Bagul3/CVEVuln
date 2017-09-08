using System.ComponentModel.DataAnnotations;
using CVEVuln.Extensions;

namespace CVEVuln.Models.Resources.User
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
