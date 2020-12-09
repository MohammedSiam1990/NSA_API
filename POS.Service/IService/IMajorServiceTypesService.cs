using POS.Entities;
using System.Collections.Generic;

namespace POS.Service.IService
{
    public interface IMajorServiceTypesService
    {
        List<MajorServiceTypes> GetMajorServiceTypes(int ServiceId);
        List<MajorServiceTypes> GetMajorServiceTypes();
        void AddMajorServiceTypes(List<MajorServiceTypes> MajorServiceTypes);
        void UpdateMajorServiceTypes(List<MajorServiceTypes> MajorServiceTypes);
        int SaveMajorServiceTypes(List<MajorServiceTypes> MajorServiceTypes);
        void DeleteMajorServiceTypes(int MajorServiceTypesId);
        MajorServiceTypes ValidateAlreadyExist(MajorServiceTypes model);
    }
}
