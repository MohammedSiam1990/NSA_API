using NSR.IService.Base;
using NSR.Service.IService;

namespace NSR.Services
{
    public class LookUpService : BaseService, IlookUpService
    {
        public string GetLookUps(string Lang)
        {
            return PosService.LookUpRepository.GetProcLookUp(Lang);
        }
    }
}
