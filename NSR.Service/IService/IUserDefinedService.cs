using NSR.Data.Entities;

namespace NSR.Service.IService
{
    public interface IUserDefinedService
    {
        int SaveUserDefined(UserDefinedObjects model);
        string GetUserDefined(int? CompanyID, int? TypeID);

    }
}
