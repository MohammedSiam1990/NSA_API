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
        public long UserId { get; set; }
        public string message { get; set; }
        public bool status { get; set; }
        public string Name { get; set; }
        public string companyId { get; set; }
        public string CompanyNameEn { get; set; }
        public string CompanyNameAr { get; set; }

        public bool success { get; set; }


    }
}
