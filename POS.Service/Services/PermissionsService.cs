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
    public class PermissionsService : BaseService, IPermissionsService
    {
        public string GetPermissionsLookUps(int MenuType, int RoldID, int? BrandID)
        {
            return PosService.PermissionsRepository.GetPermissionsLookUps(MenuType,RoldID,BrandID);
        }

        public void SavePermissions(List<Permissions> model, int RoleID)
        {
            PosService.PermissionsRepository.SavePermissions(model,RoleID);
        }
    }
}
