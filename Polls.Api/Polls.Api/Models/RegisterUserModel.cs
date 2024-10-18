using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Polls.Api.Models
{
    public class RegisterUserModel
    {
        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "Username cannot be longer than 100 characters.")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        [MinLength(10, ErrorMessage = "MobileNumber must 10 characters long.")]
        [StringLength(10, ErrorMessage = "MobileNumber must be 10 characters.")]
        public string MobileNumber { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [StringLength(100, ErrorMessage = "Email cannot be longer than 100 characters.")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        [StringLength(100, ErrorMessage = "Password cannot be longer than 100 characters.")]
        public string Password { get; set; }
    }
}
