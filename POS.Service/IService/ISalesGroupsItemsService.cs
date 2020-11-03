using POS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.IService
{
    public interface ISalesGroupsItemsService
    {
        void SaveSalesGroupsItems(List<SalesGroupsItems> model);
        string GetItemsSalesGroups(int BrandID, string ImageURL);

    }
}
