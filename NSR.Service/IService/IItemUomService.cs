using NSR.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NSR.Service.IService
{
    public interface IItemUomService
    {
        ItemUom GetItemUom(long itemUomId);
        List<ItemUom> GetItemUoms(Expression<Func<ItemUom, bool>> where);
        List<ItemUom> GetItemUoms();
        bool ValidateitemUom(ItemUom itemUom);
        void AddItemUom(ItemUom itemUom);
        void UpdateItemUom(ItemUom itemUom);
        void DeleteItemUom(long itemUomId);
        bool ValidateCodeorNameAlreadyExist(long ItemUomid, string Name);

    }
}
