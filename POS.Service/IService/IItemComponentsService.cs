using POS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.IService
{
    public interface IItemComponentsService
    {
        void SaveItemComponents(List<ItemComponents> model, int MainItemID, int MainItemUOMID);


    }
}
