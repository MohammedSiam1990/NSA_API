﻿using POS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.IService
{
    public interface IconfigService
    {
        int SaveConfig(List<Config> model);
        string GetConfig(int BranchID, int BrandID, string TabID, int TypeID);


    }
}
