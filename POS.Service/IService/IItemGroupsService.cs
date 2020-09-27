using POS.Data.Dto.Account;
using POS.Entities;
using System.Collections.Generic;

namespace POS.Service.IService
{
    public interface IItemGroupsService
    {
        int SaveItemGroup(ItemGroup Branch);
        List<GetItemGroups> GetProcItemGroups(int BrandID, string ImageName);
    }
}
