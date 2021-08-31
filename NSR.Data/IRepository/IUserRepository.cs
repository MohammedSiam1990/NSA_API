using NSR.Entities;
using Steander.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NSR.Data.IRepository
{
    public interface IUserRepository
    {
        ApplicationUser GetUser(int CompanyId);
        void AssignRollToUser(ApplicationUser User);
    }
}