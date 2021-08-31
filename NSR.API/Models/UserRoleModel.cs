using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NSR.API.Models
{
    public partial class UserRoleModel
    {
        [Key]
        public long Id { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
