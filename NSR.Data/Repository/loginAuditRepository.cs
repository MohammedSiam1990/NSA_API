using NSR.Data.Entities;
using NSR.Data.Infrastructure;
using NSR.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace NSR.Data.Repository
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
