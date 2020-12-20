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
        public string GetPermissionsLookUps(int MenuType)
        {
            return PosService.PermissionsRepository.GetPermissionsLookUps(MenuType);
        }

        public void SavePermissions(Permissions model)
        {
            PosService.PermissionsRepository.SavePermissions(model);
        }
    }
}
