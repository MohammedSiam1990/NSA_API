using POS.Data.Entities;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.Repository
{
    public class RoleBrandsRepository : Repository<RolesBrands>, IRoleBrandsRepository
    {
        public RoleBrandsRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

        public void SaveRoleBrand(List<RolesBrands> model)
        {
            base.AddRange(model);
        }
    }
}
