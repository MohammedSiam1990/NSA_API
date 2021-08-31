using NSR.Data.Entities;
using System.Collections.Generic;

namespace NSR.Service.IService
{
    public interface ISalesGroupsItemsService
    {
        void SaveSalesGroupsItems(List<SalesGroupsItems> model, int SalesGroupID);
    }
}
