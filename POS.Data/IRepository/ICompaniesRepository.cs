using POS.Core.Repository.Infrastructure;
using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.IRepository
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
       
        
    }
}
