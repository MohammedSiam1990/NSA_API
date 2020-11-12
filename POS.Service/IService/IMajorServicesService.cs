using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.IService
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
