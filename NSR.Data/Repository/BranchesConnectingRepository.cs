using NSR.Data.DataContext;
using NSR.Data.Entities;
using NSR.Data.Infrastructure;
using NSR.Data.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace NSR.Data.Repository
{
    public class BranchesConnectingRepository : Repository<BranchesConnecting>, IBranchesConnectingRepository
    {
        public BranchesConnectingRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }

        public void SaveBranchesConnecting(List<BranchesConnecting> model, int BranchID, int TypeID)
        {
            using (var context = new PosDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    var SalesGroupItems = GetMany(e => e.TypeID == TypeID && e.BranchID == BranchID).ToList();
                    base.DeleteRange(SalesGroupItems);
                    base.AddRange(model);

                    context.SaveChanges();
                    transaction.Commit();
                }
            }

        }
    }
}
