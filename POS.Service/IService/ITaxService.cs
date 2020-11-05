using POS.Data.Entities;

namespace POS.Service.IService
{
    public interface ITaxService
    {
        int SaveProcTax(Tax tax);
        string GetProcTaxes(int CompanyID);
    }
}
