﻿using Steander.Core.Entities;
using System;
using System.Collections.Generic;

namespace POS.Entities
{
    public partial class AspNetUserRoles
    {
        public string UserId { get; set; }
        public string RoleId { get; set; }

        public virtual AspNetRoles Role { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
