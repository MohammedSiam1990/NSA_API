using Microsoft.EntityFrameworkCore;
using POS.Data.DataContext;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using POS.Entities;
using Steander.Core.Entities;
using System;
using System.Linq;

namespace POS.Data.Repository
{
    public class CompaniesRepository : Repository<Companies>, ICompaniesRepository
    {
        public CompaniesRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }
        public void AddCompany(Companies Company)
        {
            Company.CreationDate = DateTime.Now;
            Add(Company);
            PosDbContext.SaveChanges();
        }
        public void UpdateCompany(Companies Company)
        {
            Company.ModificationDate = DateTime.Now;
            Update(Company);

            PosDbContext.SaveChanges();
        }
        public void SaveCompany(Companies Company)
        {
            if (Company.CompanyId == 0)
                Add(Company);
            else
                Update(Company);

            PosDbContext.SaveChanges();
        }
        public void DeleteCompany(int CompanyId)
        {
            Delete(CompanyId);
            PosDbContext.SaveChanges();
        }
        public int DeletCompanyeAndUser(Companies Company, ApplicationUser User)
        {
            int result = 0;
            using (var context = new PosDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    context.Remove(Company);
                    context.Remove(User);
                    context.SaveChanges();
                    transaction.Commit();
                    result = 1;
                }
            }
            return result;
        }
        public Companies GetCompany(int CompanyId)
        {
            return base.GetById(CompanyId);

        }

        public bool ValidateCompany(Companies Company)
        {
            if (Company.CompanyName != "")
                return true;
            else
                return false;
        }

        [Obsolete]
        public string GetCompanies()
        {
            using (var DbContext = new PosDbContext())
            {
                string Sql = "EXEC GetCompanies ";
                var data = DbContext.JsonData.FromSql(Sql).AsEnumerable().FirstOrDefault().Data;
                return data.ToString();

            }
        }
    }
}
