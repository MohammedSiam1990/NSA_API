using POS.Entities;
using System.Collections.Generic;

namespace Pos.IService
{
    public interface IMajorServicesIconsService
    {
        MajorServicesIcons GetMajorServicesIcons(int MajorServicesIconsId);
        string GetMajorServicesIcons();
        void SaveMajorServicesIcons(MajorServicesIcons MajorServicesIcons);
        void AddMajorServicesIcons(MajorServicesIcons MajorServicesIcons);
        void UpdateMajorServicesIcons(MajorServicesIcons MajorServicesIcons);
        void DeleteMajorServicesIcons(int MajorServicesIconsId);
    }
}
