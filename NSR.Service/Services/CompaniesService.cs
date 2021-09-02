using NSR.IService;
using NSR.Entities;
using NSR.IService.Base;

namespace NSR.Service
{
    public class CompaniesService : BaseService, ICompaniesService
    {
        public void AddCompany(Companies Company)
        {
            PosService.CompaniesRepository.AddCompany(Company);
        }

        public void DeleteCompany(int CompanyId)
        {
            PosService.CompaniesRepository.DeleteCompany(CompanyId);
        }

        public Companies GetCompany(int CompanyId)
        {
            return PosService.CompaniesRepository.GetCompany(CompanyId);
        }
        public string GetCompanies()
        {
            return PosService.CompaniesRepository.GetCompanies();
        }
        public void SaveCompany(Companies Company)
        {
            PosService.CompaniesRepository.SaveCompany(Company);
        }

        public void UpdateCompany(Companies Company)
        {
            PosService.CompaniesRepository.UpdateCompany(Company);
        }

        public bool ValidateCompany(Companies Company)
        {
            return PosService.CompaniesRepository.ValidateCompany(Company);
        }

        public int DeletCompanyeAndUser(int CompanyId)
        {
            var User = PosService.UserRepository.GetUser(CompanyId);
            var Company = PosService.CompaniesRepository.GetCompany(CompanyId);
            return PosService.CompaniesRepository.DeletCompanyeAndUser(Company, User);
        }
    }
}
