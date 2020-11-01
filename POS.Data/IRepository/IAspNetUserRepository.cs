using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace POS.Data.IRepository
{
    public interface IAspNetUserRepository
    {
        AspNetUsers GetAspNetUser(int CompanyId);
    }
}