
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POS.API.Helpers;
using POS.Data.DataContext;
using POS.Data.Entities;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using POS.Entities;
using Steander.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace POS.Data.Repository
{
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        public UserRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }

     
        public ApplicationUser GetUser(int CompanyId)
        {
            try
            {
                var QAspNetUser = base.Table().Where( e => e.CompanyId == CompanyId).FirstOrDefault();
                base.DbContext.Dispose();
                base.DbContext = null;
                return QAspNetUser;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }

      
    }
}
