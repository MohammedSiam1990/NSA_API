using NSR.Data.Entities;
using System.Collections.Generic;

namespace NSR.Service.IService
{
    public interface IconfigService
    {
        int SaveConfig(List<Config> model);
        string GetConfig(int TypeID, int? BranchID, int? BrandID);


    }
}
