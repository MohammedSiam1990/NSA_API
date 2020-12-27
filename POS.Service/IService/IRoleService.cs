using POS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.IService
{
    public interface IRoleService
    {
        void SaveRole(Role model);
        string GetRole(int? CompanyId);
        Role GetRoleById(int RoleId);
        int RoleAlreadyExists(Role model);
        int CheckRoleBrands(int? RoleID);

    }
}
