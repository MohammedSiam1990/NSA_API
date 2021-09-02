using NSR.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSR.Data.IRepository
{
    public interface ISchoolRepository
    {
        School GetSchool(int InsertedBy);
        List<School> GetSchools();
        void AddSchool(School School);
        void UpdateSchool(School School);
        int SaveSchool(School School, string Img);
        void DeleteSchool(int SchoolId);
        School ValidateAlreadyExist(School model);

        School GetSchoolID(int SchoolID);

        string GetProSchoolsAll();



    }
}
