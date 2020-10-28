using POS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.IRepository
{
    public interface IItemComponentsRepository
    {
        void AddItemComponents(List<ItemComponents> itemComponents);
        void DeleteItemComponents(long MainItemID, long MainItemUOMID);
        void SaveItemComponents(long MainItemID, long MainItemUOMID, List<ItemComponents> model);


    }
}
