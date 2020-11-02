
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POS.API.Helpers;
using POS.Data.DataContext;
using POS.Data.Entities;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace POS.Data.Repository
{
    public class AspNetUserRepository : Repository<AspNetUsers>, IAspNetUserRepository
    {
        public AspNetUserRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }

     
        public AspNetUsers GetAspNetUser(int CompanyId)
        {
            return base.GetById(e=>e.CompanyId==CompanyId);
        }

      
    }
}
