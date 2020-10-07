using POS.Entities;
using System.Collections.Generic;

namespace POS.Service.IService
{
    public interface IItemGroupsService
    {
        int SaveItemGroup(ItemGroup Branch);
        string GetProcItemGroups(int BrandID, string ImageName);
    }
}
