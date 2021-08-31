using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace Steander.Core.DTOs
{
    public class UserDto
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }
        //public string LastLoginDataTimeFormated { get; set; }

        //public bool ForceToChangePassword { get; set; }

        //public IEnumerable<string> UserRoles { get; set; }

        //public bool IsActive { get; set; }

        //public string ControlType { get; set; }

    }
}
