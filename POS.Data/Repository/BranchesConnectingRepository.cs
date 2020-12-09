using POS.Data.DataContext;
using POS.Data.Entities;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace POS.Data.Repository
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
