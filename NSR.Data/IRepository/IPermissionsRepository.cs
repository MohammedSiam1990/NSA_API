﻿using NSR.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NSR.Data.IRepository
{
    public interface IPermissionsRepository
    {
        void SavePermissions(Permissions model,int RoleID,int MenuID);
        string GetPermissions(int MenuType, int RoldID, int? BrandID);
    }
}
