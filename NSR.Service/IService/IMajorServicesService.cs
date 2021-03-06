using NSR.Entities;
using System.Collections.Generic;

namespace NSR.Service.IService
{
    public interface IMajorServicesService
    {
        MajorServices GetMajorService(int ServiceId);
        List<MajorServices> GetMajorServices();
        void AddMajorServices(MajorServices MajorServices);
        void UpdateMajorServices(MajorServices MajorServices);
        void SaveMajorServices(MajorServices MajorServices);
        void DeleteMajorServices(int MajorServicesId);
    }
}
