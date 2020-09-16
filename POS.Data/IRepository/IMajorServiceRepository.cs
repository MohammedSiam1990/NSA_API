using POS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.IRepository
{
    public interface IMajorServiceRepository
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
