using POS.Data.Entities;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.Repository
{
    public class loginAuditRepository : Repository<LoginAudit>, IloginAuditRepository
    {
        public loginAuditRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

        public void SaveLoginAudit(LoginAudit model)
        {
            Add(model);
        }
    }
}
