using NSR.Entities;

namespace NSR.IService
{
    public interface ICompaniesService
    {
        Companies GetCompany(int CompanyId);
        string GetCompanies();
        bool ValidateCompany(Companies Company);
        void SaveCompany(Companies Company);
        void AddCompany(Companies Company);
        void UpdateCompany(Companies Company);
        void DeleteCompany(int CompanyId);
        int DeletCompanyeAndUser(int CompanyId);
    }
}
