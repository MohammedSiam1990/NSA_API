using POS.Entities;

namespace Pos.IService
{
    public interface IMajorServicesIconsService
    {
        MajorServicesIcons GetMajorServicesIcons(int MajorServicesIconsId);
        string GetMajorServicesByIcons(int ServiceId);
        void SaveMajorServicesIcons(MajorServicesIcons MajorServicesIcons);
        void AddMajorServicesIcons(MajorServicesIcons MajorServicesIcons);
        void UpdateMajorServicesIcons(MajorServicesIcons MajorServicesIcons);
        void DeleteMajorServicesIcons(int MajorServicesIconsId);
    }
}
