using NSR.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSR.Data.IRepository
{
    public interface IUniversityRepository
    {
        University GetUniversity(int InsertedBy);

        University GetUniversityID(int UniversityID);

        List<University> GetUniversitys();
        void AddUniversity(University University);
        void UpdateUniversity(University University);
        int SaveUniversity(University University, string Img);
        void DeleteUniversity(int UniversityId);
        University ValidateAlreadyExist(University model);

        string GetProUniversitysAll();

    }
}
