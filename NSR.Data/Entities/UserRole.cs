using System;
using System.Collections.Generic;
using System.Text;

namespace NSR.Data.Entities
{
    public class UserRole
    {
        public long Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

    }
}
