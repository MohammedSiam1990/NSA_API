using NSR.IService;
using NSR.Entities;
using NSR.IService.Base;

namespace NSR.Service
{
    public class MajorServicesIconsService : BaseService, IMajorServicesIconsService
    {
        public void AddMajorServicesIcons(MajorServicesIcons MajorServicesIcons)
        {
            PosService.MajorServicesIconsRepository.AddMajorServicesIcons(MajorServicesIcons);
        }

        public void DeleteMajorServicesIcons(int MajorServicesIconsId)
        {
            PosService.MajorServicesIconsRepository.DeleteMajorServicesIcons(MajorServicesIconsId);
        }

        public MajorServicesIcons GetMajorServicesIcons(int MajorServicesIconsId)
        {
            return PosService.MajorServicesIconsRepository.GetMajorServicesIcons(MajorServicesIconsId);
        }
        public string GetMajorServicesByIcons(int ServiceId)
        {
            return PosService.MajorServicesIconsRepository.GetMajorServicesByIcons(ServiceId);
        }
        public void SaveMajorServicesIcons(MajorServicesIcons MajorServicesIcons)
        {
            PosService.MajorServicesIconsRepository.SaveMajorServicesIcons(MajorServicesIcons);
        }

        public void UpdateMajorServicesIcons(MajorServicesIcons MajorServicesIcons)
        {
            PosService.MajorServicesIconsRepository.UpdateMajorServicesIcons(MajorServicesIcons);
        }


    }
}
