using POS.Data.DataContext;
using POS.Data.Entities;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace POS.Data.Repository
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
                        var OldPrice = GetMany(e => e.PriceTemplateID==20).ToList();
                        base.DeleteRange(OldPrice);

                    }
                    //base.AddRange(model);
                }
            }
        }

    }
}
