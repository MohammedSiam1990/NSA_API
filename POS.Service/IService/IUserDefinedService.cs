using POS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.IService
{
    public interface IUserDefinedService
    {
        void SaveUserDefined(UserDefinedObjects model);
        string GetUserDefined(int? CompanyID, int? TypeID);

    }
}
