using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.IService
{
   public interface IMajorServiceTypesService
    {
        MajorServiceTypes GetMajorServiceTypes(int MajorServiceTypesId);
        List<MajorServiceTypes> GetMajorServiceTypes();
        List<MajorServiceTypes> GetMajorServiceTypesByMajorService(int ServiceId);
        bool ValidateMajorServiceTypes(MajorServiceTypes MajorServiceTypes);
        void SaveMajorServiceTypes(MajorServiceTypes MajorServiceTypes);
        void AddMajorServiceTypes(MajorServiceTypes MajorServiceTypes);
        void UpdateMajorServiceTypes(MajorServiceTypes MajorServiceTypes);
        void DeleteMajorServiceTypes(int MajorServiceTypesId);
    }
}
