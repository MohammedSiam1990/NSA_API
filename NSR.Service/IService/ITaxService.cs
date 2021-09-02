using NSR.Data.Entities;

namespace NSR.Service.IService
{
    public interface ITaxService
    {
        int SaveProcTax(Tax tax);
        string GetProcTaxes(int CompanyID);
    }
}
