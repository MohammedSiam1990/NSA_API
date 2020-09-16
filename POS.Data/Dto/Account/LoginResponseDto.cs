using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.Dto
{
    public class LoginResponseDto
    {
        public string Token { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string UserId { get; set; }
        public string message { get; set; }
        public bool status { get; set; }

    }
}
