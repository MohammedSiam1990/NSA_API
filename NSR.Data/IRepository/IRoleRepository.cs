﻿using NSR.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NSR.Data.IRepository
{
    public interface IRoleRepository
    {
        void SaveRole(Role model);
        string GetRole(int? CompanyId);
        Role GetRoleById(int RoleId);
        int RoleAlreadyExists(Role model);
        int CheckRoleBrands(int? RoleID);
    }
}
