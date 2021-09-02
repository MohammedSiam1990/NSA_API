using NSR.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSR.Service.IService
{
    public interface IUserRoleService
    {
        void SaveUserRole(List<UserRole> model, int RoleID);

    }
}
