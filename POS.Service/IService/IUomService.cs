using POS.Data.Dto.Procedure;
using POS.Data.Entities;
using System.Collections.Generic;

namespace POS.Service.IService
{
    public interface IUomService
    {
        int SaveProcUom(Uom uom);
        List<GetUoms> GetProcUoms(int CompanyID);
    }
}
