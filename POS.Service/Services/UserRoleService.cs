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
    public class UserRoleService : BaseService, IUserRoleService
    {
        public void SaveUserRole(List<UserRole> model, int RoleID)
        {
            PosService.UserRoleRepository.SaveUserRole(model, RoleID);
        }

    }
}
