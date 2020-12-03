using POS.Data.Entities;
using System.Collections.Generic;

namespace POS.Service.IService
{
    public interface IconfigService
    {
        int SaveConfig(List<Config> model);
        string GetConfig(int TypeID, int? BranchID, int? BrandID);


    }
}
