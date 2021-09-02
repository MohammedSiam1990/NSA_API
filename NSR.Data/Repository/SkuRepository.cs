using Microsoft.EntityFrameworkCore;
using NSR.Data.Infrastructure;
using NSR.Data.IRepository;
using NSR.Entities;
using System.Linq;

namespace NSR.Data.Repository
{
    public class SkuRepository : Repository<Sku>, ISkuRepository
    {
        public SkuRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }

        public void DeleteSku(long ItemId)
        {
            var Skus = GetMany(e => e.ItemUom.ItemId == ItemId).ToList();
            base.DeleteRange(Skus);
        }

        public Sku ValidateAlreadyExist(Sku model, long ItemId)
        {
            var Sku = base.Table()
                .Where(e => e.Skuid != model.Skuid && e.ItemUom.Item.ItemId != ItemId && e.ItemUom.Item.StatusId != 3 && e.BrandID == model.BrandID && (e.Code == model.Code))
                .Include(e => e.ItemUom).ThenInclude(e => e.Item).FirstOrDefault();
            base.DbContext.Dispose();
            base.DbContext = null;
            return Sku;
        }
    }
}
