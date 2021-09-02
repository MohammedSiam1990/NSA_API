using System;
using System.Collections.Generic;
using System.Text;

namespace NSR.Data.IRepository
{
    public interface IAuthRepository
    {
        string GetAllUsersAsync(int UserType, int? CompanyID);
    }
}
