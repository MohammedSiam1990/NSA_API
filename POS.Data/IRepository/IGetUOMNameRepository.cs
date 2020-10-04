using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.IRepository
{
    public interface IGetUOMNameRepository
    {
        string GetUOMName(int BrandID);
    }
}
