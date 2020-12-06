using POS.Data.Entities;
using System.Collections.Generic;

namespace POS.Service.IService
{
    public interface IItemComponentsService
    {
        void SaveItemComponents(List<ItemComponents> model, int MainItemID, int MainItemUOMID);

    }
}
