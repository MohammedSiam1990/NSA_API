using NSR.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NSR.Data.IRepository
{
    public interface ISalesGroupsItemsRepository
    {
        void SaveSalesGroupsItems(List<SalesGroupsItems> model,int SalesGroupID);
    }
}
