using NSR.Data.Entities;
using NSR.IService.Base;
using NSR.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSR.Service.Services
{
    public class RoleService : BaseService, IRoleService
    {
        public int CheckRoleBrands(int? RoleID)
        {
            return PosService.RoleRepository.CheckRoleBrands(RoleID);
        }

        public string GetRole(int? CompanyId)
        {
            return PosService.RoleRepository.GetRole(CompanyId);
        }

        public Role GetRoleById(int RoleId)
        {
            return PosService.RoleRepository.GetRoleById(RoleId);
        }

        public int RoleAlreadyExists(Role model)
        {
            return PosService.RoleRepository.RoleAlreadyExists(model);
        }

        public void SaveRole(Role model)
        {
            PosService.RoleRepository.SaveRole(model);
        }
    }
}
