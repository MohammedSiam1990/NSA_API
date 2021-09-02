using NSR.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSR.Data.IRepository
{
    public interface IMajorServiceRepository
    {
        MajorServices GetMajorService(int ServiceId);
        List<MajorServices> GetMajorServices();
        void AddMajorServices(MajorServices MajorServices);
        void UpdateMajorServices(MajorServices MajorServices);
        void SaveMajorServices(MajorServices MajorServices);
        void DeleteMajorServices(int MajorServicesId);

    }
}
