using NSR.Entities;
using NSR.IService.Base;
using NSR.Service.IService;

namespace NSR.Service.Services
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
