using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace POS.Data.IRepository
{
    public interface IItemRepository
    {
        List<Item> GetItemAll(Expression<Func<Item, bool>> where);
        string GetProcItemData(int BrandID, string ImageURL);
        bool ValidateItem(Item Item);
        void AddItem(Item Item);
        void UpdateItem(Item Item);
        int ValidateNameAlreadyExist( Item model);
        string GetUOMName(int BrandID);



    }
}