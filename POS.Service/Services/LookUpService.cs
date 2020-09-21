using POS.IService.Base;
using POS.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Services
{
    public class LookUpService : BaseService, IloockUpService
    {
        public string GetLookUps(string Lang)
        {
            return PosService.LookUpRepository.GetProcLookUp(Lang);
        }
    }
}
