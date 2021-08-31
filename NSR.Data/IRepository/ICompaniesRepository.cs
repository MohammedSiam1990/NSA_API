using NSR.Core.Repository.Infrastructure;
using NSR.Entities;
using Steander.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NSR.Data.IRepository
{
  public  interface ICompaniesRepository
    {
        Companies GetCompany(int CompanyId);
        string GetCompanies();
        bool ValidateCompany(Companies Company);
        void SaveCompany(Companies Company);
        void AddCompany(Companies Company);
        void UpdateCompany(Companies Company);
        void  DeleteCompany(int CompanyId);
        int DeletCompanyeAndUser(Companies Company, ApplicationUser User);


    }
}
