using POS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.IRepository
{
    public interface IUserDefinedRepository
    {
        void SaveUserDefined(UserDefinedObjects model);
        string GetUserDefined(int? CompanyID , int? TypeID);
    }
}
