using NSR.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NSR.Data.IRepository
{
    public interface IUserDefinedRepository
    {
        int SaveUserDefined(UserDefinedObjects model);
        string GetUserDefined(int? CompanyID , int? TypeID);
    }
}
