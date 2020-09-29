using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace POS.Data.IRepository
{
    public interface IItemRepository
    {
        List<Item> GetItemAll(Expression<Func<Item, bool>> where);
        Item GetItem(Expression<Func<Item, bool>> where);
        bool ValidateItem(Item Item);
        void AddItem(Item Item);
        void UpdateItem(Item Item);
        int ValidateNameAlreadyExist( Item model);
    }
}