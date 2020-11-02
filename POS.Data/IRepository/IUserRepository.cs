using POS.Entities;
using Steander.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace POS.Data.IRepository
{
    public interface IUserRepository
    {
        ApplicationUser GetUser(int CompanyId);
    }
}