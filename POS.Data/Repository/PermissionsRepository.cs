using POS.Data.Entities;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.Repository
{
    public class PermissionsRepository : Repository<Permissions>, IPermissionsRepository
    {
        public PermissionsRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

        public string GetPermissionsLookUps(int MenuType)
        {
            throw new NotImplementedException();
        }

        public void SavePermissions(Permissions model)
        {
            throw new NotImplementedException();
        }
    }
}
