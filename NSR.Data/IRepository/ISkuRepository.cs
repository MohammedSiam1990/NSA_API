using NSR.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NSR.Data.IRepository
{
    public interface ISkuRepository
    {
        Sku ValidateAlreadyExist(Sku model,long ItemId);
        void DeleteSku(long ItemId);
    }
}