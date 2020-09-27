using POS.Data.Dto.Procedure;
using POS.Data.Entities;
using System.Collections.Generic;

namespace POS.Service.IService
{
    public interface ITaxService
    {
        int SaveProcTax(Tax tax);
        List<GetTaxes> GetProcTaxes(int CompanyID);
    }
}
