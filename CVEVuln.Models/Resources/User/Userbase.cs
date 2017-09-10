using System.ComponentModel.DataAnnotations;

namespace CVEVuln.Models.Resources.User
{
    public class Userbase
    {
        public int AccountId { get; set; }

        [Required]
        public string Username { get; set; }

        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }
    }
}
