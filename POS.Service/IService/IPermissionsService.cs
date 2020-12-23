using POS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.IService
{
    public interface IPermissionsService
    {
        void SavePermissions(List<Permissions> model, int RoleID);
        string GetPermissions(int MenuType, int RoldID, int? BrandID);

    }
}
