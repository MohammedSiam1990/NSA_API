using NSR.Data.DataContext;
using NSR.Data.Entities;
using NSR.Data.Infrastructure;
using NSR.Data.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace NSR.Data.Repository
{
    public class PriceTemplateDetailsRepository : Repository<PriceTemplateDetails>, IPriceTemplateDetailsRepository
    {
        public PriceTemplateDetailsRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

        public void DeletePriceTemplateDetails(int PriceTemplateID, List<PriceTemplateDetails> model)
        {
            using (var context = new PosDbContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    if (PriceTemplateID != 0)
                    {
                        var OldPrice = GetMany(e => e.PriceTemplateID== PriceTemplateID).ToList();
                        base.DeleteRange(OldPrice);
                        transaction.Commit();

                    }
                    //base.AddRange(model);
                }
            }
        }

    }
}
