using POS.IService.Base;
using POS.Service.IService;

namespace POS.Services
{
    public class LookUpService : BaseService, IlookUpService
    {
        public string GetLookUps(string Lang)
        {
            return PosService.LookUpRepository.GetProcLookUp(Lang);
        }
    }
}
