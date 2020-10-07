using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace POS.Data.Dto
{
    public class LoginViewModel
    {

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        public string Lang { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string Password { get; set; }

        public int UserType { get; set; }

    }
}
