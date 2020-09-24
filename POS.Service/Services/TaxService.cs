using POS.Data.Dto.Procedure;
using POS.Data.Entities;
using POS.IService.Base;
using POS.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.Services
{
   public class TaxService : BaseService, ITaxService
    {
        public int SaveProcTax(Tax tax)
        {
            return PosService.taxRepository.SaveProcTax(tax);
        }

        public List<GetTaxes> GetProcTaxes(int CompanyID)
        {
            return PosService.taxRepository.GetProcTaxes(CompanyID);
        }
    }

}
