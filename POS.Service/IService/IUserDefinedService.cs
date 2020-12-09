using POS.Data.Entities;

namespace POS.Service.IService
{
    public interface IUserDefinedService
    {
        int SaveUserDefined(UserDefinedObjects model);
        string GetUserDefined(int? CompanyID, int? TypeID);

    }
}
