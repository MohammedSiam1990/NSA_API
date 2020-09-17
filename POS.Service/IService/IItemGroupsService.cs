using POS.Data.Dto.Account;
using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.IService
{
   public interface IItemGroupsService
    {
        int SaveItemGroup(ItemGroup Branch);
       List< GetProcItemGroups> GetProcItemGroups(int BrandID, string ImageName);
    }
}
