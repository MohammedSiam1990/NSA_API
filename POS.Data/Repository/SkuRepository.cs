
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POS.API.Helpers;
using POS.Data.DataContext;
using POS.Data.Entities;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace POS.Data.Repository
{
    public class SkuRepository : Repository<Sku>, ISkuRepository
    {
        public SkuRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }



        public Sku ValidateNameAlreadyExist(Sku model)
        {
            try
            {
                var Sku = base.Table()
                    .Where(e => e.Skuid != model.Skuid && e.BrandID == model.BrandID &&  (e.Code == model.Code))
                    .Include(e => e.ItemUom).ThenInclude(e => e.Item).FirstOrDefault();
                base.DbContext.Dispose();
                base.DbContext = null;
                return Sku;
           }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }

        }
    }
}
