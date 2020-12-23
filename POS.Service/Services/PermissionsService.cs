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
        public string GetPermissions(int MenuType, int RoldID, int? BrandID)
        {
            return PosService.PermissionsRepository.GetPermissions(MenuType,RoldID,BrandID);
        }

        public void SavePermissions(Permissions model, int RoleID,int MenuID)
        {
            PosService.PermissionsRepository.SavePermissions(model,RoleID, MenuID);
        }
    }
}
