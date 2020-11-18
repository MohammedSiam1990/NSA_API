using POS.Data.Entities;
using System.Collections.Generic;

namespace POS.Service.IService
{
    public interface ISalesGroupsItemsService
    {
        void SaveSalesGroupsItems(List<SalesGroupsItems> model, int SalesGroupID);
    }
}
