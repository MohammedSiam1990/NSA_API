using NSR.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NSR.Data.IRepository
{
    public interface IItemComponentsRepository
    {
        void SaveItemComponents(List<ItemComponents> model, int MainItemID, int MainItemUOMID);
    }
}
