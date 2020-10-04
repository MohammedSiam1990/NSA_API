using POS.IService.Base;
using POS.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.Services
{
    public class GetUOMNameService : BaseService, IGetUOMNameService
    {
        public string GetUOMName(int BrandID)
        {
            return PosService.GetUOMNameRepository.GetUOMName(BrandID);
        }
    }
}
