using POS.Core.Repository.Infrastructure;
using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Pos.IService
{
  public  interface ICompaniesService
    {
          Companies GetCompany(int CompanyId);
        List<Companies> GetCompanies();
         bool ValidateCompany(Companies Company);
        void SaveCompany(Companies Company);
        void AddCompany(Companies Company);
        void UpdateCompany(Companies Company);
        void  DeleteCompany(int CompanyId);

    }
}
