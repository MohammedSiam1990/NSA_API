using POS.Data.Dto.Procedure;
using POS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.IRepository
{
    public interface ITaxRepository
    {
        int SaveProcTax(Tax tax);
        List<GetTaxes> GetProcTaxes(int CompanyID);
    }
}
