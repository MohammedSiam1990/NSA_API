using POS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.IRepository
{
    public interface IConfigRepository
    {
        int SaveConfig(List<Config>Added, List<Config>Updated);
        string GetConfig(int? BranchID, int? BrandID, int TypeID);
    }
}
