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
        MajorService GetMajorService(int ServiceId);
        List<MajorService> GetMajorServices();
        bool ValidateMajorService(MajorService majorService);
        void SaveMajorService(MajorService majorService);
        void AddMajorService(MajorService majorService);
        void UpdateMajorService(MajorService majorService);
        void DeleteMajorService(int ServiceId);
    }
}
