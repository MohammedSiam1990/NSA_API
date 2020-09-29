using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace Pos.IService
{
    public interface IItemService
    {
        string GetItems(int BrandID, string ImageURL);
        List<Item> GetItemAll();
        bool ValidateItem(Item Item);
        void AddItem(Item Item);
        void UpdateItem(Item Item);
        int ValidateNameAlreadyExist(Item model);
    }
}
