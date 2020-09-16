using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace POS.Data.IRepository
{
        public interface IMajorServiceTypesRepository
        {
            MajorServiceTypes GetMajorServiceTypes(int MajorServiceTypesId);
            List<MajorServiceTypes> GetMajorServiceTypes();
            List<MajorServiceTypes> GetMajorServiceTypesByMajorService(Expression<Func<MajorServiceTypes, bool>> where);
            bool ValidateMajorServiceTypes(MajorServiceTypes MajorServiceTypes);
            void SaveMajorServiceTypes(MajorServiceTypes MajorServiceTypes);
            void AddMajorServiceTypes(MajorServiceTypes MajorServiceTypes);
            void UpdateMajorServiceTypes(MajorServiceTypes MajorServiceTypes);
            void DeleteMajorServiceTypes(int MajorServiceTypesId);
        }
    }
