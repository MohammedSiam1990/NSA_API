using POS.Data.Dto.Procedure;
using POS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.IService
{
   public interface ITaxService
    {
        int SaveProcTax(Tax tax);
        List<GetTaxes> GetProcTaxes(int CompanyID);
    }
}
