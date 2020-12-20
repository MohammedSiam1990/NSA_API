using POS.Data.Entities;
using POS.IService.Base;
using POS.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.Services
{
    public class RoleService : BaseService, IRoleService
    {
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
