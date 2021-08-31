using NSR.Entities;

namespace NSR.Service.IService
{
    public interface IItemGroupsService
    {
        int SaveItemGroup(ItemGroup Branch);
        string GetProcItemGroups(int BrandID, string ImageName);
    }
}
