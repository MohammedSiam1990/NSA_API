using POS.Data.Dto.Procedure;
using POS.Data.Entities;
using POS.IService.Base;
using POS.Service.IService;
using System.Collections.Generic;

namespace POS.Service.Services
{
    public class UomService : BaseService, IUomService
    {
        public int SaveProcUom(Uom uom)
        {
            return PosService.uomRepository.SaveProcUom(uom);
        }

        public List<GetUoms> GetProcUoms(int CompanyID)
        {
            return PosService.uomRepository.GetProcUoms(CompanyID);
        }
    }

}