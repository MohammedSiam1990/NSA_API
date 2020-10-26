using POS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.IRepository
{
    public interface IItemComponentsRepository
    {
        void AddItemComponents(ItemComponents itemComponents);
        void DeleteItemComponents(long ItemComponentID);

    }
}
