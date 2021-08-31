using NSR.Entities;
using System.Collections.Generic;

namespace NSR.Service.IService
{
    public interface IUniversityService
    {


        University GetUniversity(int InsertedBy);
        University GetUniversityID(int UniversityID);
        List<University> GetUniversitys();
        void AddUniversity(University University);
        void UpdateUniversity(University University);
        int SaveUniversity(University University,string Img);
        void DeleteUniversity(int UniversityId);
        University ValidateAlreadyExist(University model);


        string GetProUniversitysAll();
    }
}
