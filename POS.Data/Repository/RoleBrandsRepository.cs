using POS.Data.DataContext;
using POS.Data.Entities;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.Data.Repository
{
    public class RoleBrandsRepository : Repository<RolesBrands>, IRoleBrandsRepository
    {
        public RoleBrandsRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

        public void SaveRoleBrand(List<RolesBrands> model, int RollID)
        {
            using (var context = new PosDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {

                    var Permission = GetMany(e => e.RoleID == RollID).ToList();
                    base.DeleteRange(Permission);

                    foreach (var m in model)
                    {
                        m.Id = 0;
                    }
                    base.AddRange(model);
                    transaction.Commit();

                }
            }

        }
    }
}
