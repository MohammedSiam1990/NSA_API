using System;
using System.Collections.Generic;

namespace NSR.Data.Dto
{
    public class UserManagerResponse
    {

        public string message { get; set; }
        //public bool EmailConfirmed { get; set; }
        public bool success { get; set; }
        public IEnumerable<string> Errors { get; set; }
        public DateTime? ExpireDate { get; set; }


    }
}