using NSR.Data.Dto.Procedure;
using NSR.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NSR.Data.IRepository
{
    public interface ITaxRepository
    {
        int SaveProcTax(Tax tax);
        string GetProcTaxes(int CompanyID);
    }
}
