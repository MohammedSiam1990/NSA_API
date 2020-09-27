using POS.API.Helpers;
using POS.Data.DataContext;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using POS.Entities;
using System;
using System.Collections.Generic;
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
            try
            {
                Add(Company);
                PosDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public void UpdateCompany(Companies Company)
        {

            try
            {

                Update(Company);

                PosDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }
        public void SaveCompany(Companies Company)
        {
            try
            {
                if (Company.CompanyId == 0)
                    Add(Company);
                else
                    Update(Company);

                PosDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }
        public void DeleteCompany(int CompanyId)
        {
            try
            {
                Delete(CompanyId);
                PosDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public Companies GetCompany(int CompanyId)
        {

            try
            {
                return base.GetById(CompanyId);
                //return PosDbContext.Database.SqlQuery<Companies>(
                //                @"EXEC GetCompany
                //                @CompanyId",

                //    new SqlParameter("@EmailTemplateName", CompanyId)).FirstOrDefault();

            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }

        }



        public bool ValidateCompany(Companies Company)
        {
            try
            {
                if (Company.CompanyName != "")
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

        public List<Companies> GetCompanies()
        {
            try
            {
                return base.GetAll().ToList();
            }
            catch (Exception ex)
            {
                Exceptions.ExceptionError.SaveException(ex);
            }
            return null;

        }



    }
}
