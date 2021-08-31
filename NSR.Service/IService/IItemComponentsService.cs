using NSR.Data.Entities;
using System.Collections.Generic;

namespace NSR.Service.IService
{
    public interface IItemComponentsService
    {
        void SaveItemComponents(List<ItemComponents> model, int MainItemID, int MainItemUOMID);

    }
}
