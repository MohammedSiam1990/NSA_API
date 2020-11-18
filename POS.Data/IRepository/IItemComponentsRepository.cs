using POS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.IRepository
{
    public interface IItemComponentsRepository
    {
        void SaveItemComponents(List<ItemComponents> model, int MainItemID, int MainItemUOMID);
    }
}
