using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace POS.Data.IRepository
{
    public interface IItemUomRepository
    {
        ItemUom GetItemUom(long itemUomId);
        List<ItemUom> GetItemUoms(Expression<Func<ItemUom, bool>> where);
        List<ItemUom> GetItemUoms();
        bool ValidateitemUom(ItemUom itemUom);
        void AddItemUom(ItemUom itemUom);
        void UpdateItemUom(ItemUom itemUom);
        void DeleteItemUom(long itemUomId);
        bool ValidateCodeorNameAlreadyExist(Expression<Func<ItemUom, bool>> where);
        bool ValidateCodeorNameArAlreadyExist(Expression<Func<ItemUom, bool>> where);

    }

}
