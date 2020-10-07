using POS.Entities;
using POS.IService.Base;
using POS.Service.IService;
using System.Collections.Generic;

namespace POS.Service.Services
{
    public class ItemGroupsService : BaseService, IItemGroupsService
    {
        public int SaveItemGroup(ItemGroup itemGroup)
        {
            return PosService.ItemGroupsRepository.SaveItemGroup(itemGroup);
        }

        public string GetProcItemGroups(int BrandID, string ImageName)
        {
            return PosService.ItemGroupsRepository.GetProcItemGroups(BrandID, ImageName);
        }
    }
}
