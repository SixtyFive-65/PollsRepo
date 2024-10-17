using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Polls.Api.Models
{
    public class UserModel
    {
        [Required]
        [EmailAddress]
        public string Username { get; set; }
        [Required]
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
