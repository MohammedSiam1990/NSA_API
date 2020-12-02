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
    public class PriceTemplateDetailsRepository : Repository<PriceTemplateDetails>, IPriceTemplateDetailsRepository
    {
        public PriceTemplateDetailsRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }

        public void DeletePriceTemplateDetails(int PriceTemplateID, List<PriceTemplateDetails> model)
        {
            try
            {
                using (var context = new PosDbContext())
                {
                    using (var transaction = context.Database.BeginTransaction())
                    {
                        var OldPrice = GetMany(e => e.PriceTemplateID == PriceTemplateID).ToList();
                        base.DeleteRange(OldPrice);
                        foreach(PriceTemplateDetails m in model)
                        {
                            m.PriceTemplateDetailsID = 0;
                        }
                        base.AddRange(model);
                    }
                }

            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }

        }

    }
}
