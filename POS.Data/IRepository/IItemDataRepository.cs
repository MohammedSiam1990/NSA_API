using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.IRepository
{
    public interface IItemDataRepository
    {
        string GetProcItemData(int BrandID,string ImageURL);

    }
}
