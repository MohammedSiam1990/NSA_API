using POS.Data.Dto.Account;
using POS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.IRepository
{
  public interface IItemGroupsRepository
    {
        int SaveItemGroup(ItemGroup Branch);
        List<GetItemGroups> GetProcItemGroups(int BrandID, string ImageName);
    }
}
