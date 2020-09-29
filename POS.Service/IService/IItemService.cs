using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.IService
{
    public interface IItemService
    {
        string GetItems(int BrandID, string ImageURL);

    }
}
