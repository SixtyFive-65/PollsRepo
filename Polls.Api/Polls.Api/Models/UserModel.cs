﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Polls.Api.Models
{
    public class UserModel
    {
        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "Username cannot be longer than 100 characters.")]
        public string Username { get; set; }

        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        [StringLength(100, ErrorMessage = "Password cannot be longer than 100 characters.")]
        public string Password { get; set; }
    }
}
