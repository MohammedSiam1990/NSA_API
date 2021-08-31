using NSR.Data.Entities;
using NSR.IService.Base;
using NSR.Service.IService;

namespace NSR.Service.Services
{
    public class UserDefinedService : BaseService, IUserDefinedService
    {
        public string GetUserDefined(int? CompanyID, int? TypeID)
        {
            return PosService.UserDefinedRepository.GetUserDefined(CompanyID, TypeID);
        }

        public int SaveUserDefined(UserDefinedObjects model)
        {
            return PosService.UserDefinedRepository.SaveUserDefined(model);
        }
    }
}
