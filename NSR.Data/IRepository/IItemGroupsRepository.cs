using NSR.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NSR.Data.IRepository
{
  public interface IItemGroupsRepository
    {
        int SaveItemGroup(ItemGroup Branch);
        string GetProcItemGroups(int BrandID, string ImageName);
    }
}
