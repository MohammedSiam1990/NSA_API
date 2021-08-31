using System;
using System.Collections.Generic;
using System.Text;

namespace NSR.Data.IRepository
{
    public interface IItemDataRepository
    {
        string GetProcItemData(int BrandID,string ImageURL,string Lang);
        string GetProcActiveItemData(int BrandID,string ImageURL,string Lang);

    }
}
