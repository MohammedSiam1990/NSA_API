using POS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.IRepository
{
    public interface IPermissionsRepository
    {
        void SavePermissions(List<Permissions> model,int RoleID,int MenuID);
        string GetPermissions(int MenuType, int RoldID, int? BrandID);
    }
}
