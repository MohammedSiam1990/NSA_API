using POS.API.Helpers;
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
    public class BranchesConnectingRepository : Repository<BranchesConnecting>, IBranchesConnectingRepository
    {
        public BranchesConnectingRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }

        public void SaveBranchesConnecting(List<BranchesConnecting> model)
        {
            using (var context = new PosDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        long TypeID = model.First().TypeID;
                        int BranchID = model.First().BranchID;
                        var SalesGroupItems = GetMany(e => e.TypeID == TypeID && e.BranchID == BranchID).ToList();
                        base.DeleteRange(SalesGroupItems);
                        base.AddRange(model);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new AppException(ex.Message);
                    }
                }
            }

        }
    }
}
