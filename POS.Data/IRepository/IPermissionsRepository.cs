﻿using POS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.IRepository
{
    public interface IPermissionsRepository
    {
        void SavePermissions(Permissions model);
        string GetPermissionsLookUps(int MenuType);
    }
}
