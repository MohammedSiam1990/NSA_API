using POS.Data.Dto.Procedure;
using POS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.IService
{
   public interface IUomService
    {
        int SaveProcUom(Uom uom);
        List<GetUoms> GetProcUoms(int CompanyID);
    }
}
