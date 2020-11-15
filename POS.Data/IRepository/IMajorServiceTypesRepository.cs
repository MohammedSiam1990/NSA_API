﻿using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.IRepository
{
    public interface IMajorServiceTypesRepository
    {
        MajorServiceTypes GetMajorServiceTypes(int ServiceId);
        List<MajorServiceTypes> GetMajorServiceTypes();
        void AddMajorServiceTypes(MajorServiceTypes MajorServiceTypes);
        void UpdateMajorServiceTypes(MajorServiceTypes MajorServiceTypes);
        void SaveMajorServiceTypes(MajorServiceTypes MajorServiceTypes);
        void DeleteMajorServiceTypes(int MajorServiceTypesId);

    }
}
