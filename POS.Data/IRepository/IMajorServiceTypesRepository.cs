using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.IRepository
{
    public interface IMajorServiceTypesRepository
    {
        List<MajorServiceTypes> GetMajorServiceTypes(int ServiceId);
        List<MajorServiceTypes> GetMajorServiceTypes();
        void AddMajorServiceTypes(List<MajorServiceTypes> MajorServiceTypes);
        void UpdateMajorServiceTypes(List<MajorServiceTypes> MajorServiceTypes);
        int SaveMajorServiceTypes(List<MajorServiceTypes> MajorServiceTypes);
        void DeleteMajorServiceTypes(int MajorServiceId);
        MajorServiceTypes ValidateAlreadyExist(MajorServiceTypes model);

    }
}
