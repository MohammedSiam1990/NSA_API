using NSR.Entities;
using System.Collections.Generic;

namespace NSR.Service.IService
{
    public interface ISchoolService
    {


        School GetSchoolID(int SchoolID);
        School GetSchool(int InsertedBy);
        List<School> GetSchools();
        void AddSchool(School School);
        void UpdateSchool(School School);
        int SaveSchool(School School, string Img);
        void DeleteSchool(int SchoolId);
        School ValidateAlreadyExist(School model);

        string GetProSchoolsAll();

    }
}
