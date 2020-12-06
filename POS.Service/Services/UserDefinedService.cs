using POS.Data.Entities;
using POS.IService.Base;
using POS.Service.IService;

namespace POS.Service.Services
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
