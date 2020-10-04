using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.IService
{
   public interface IGetUOMNameService
    {
        string GetUOMName(int BrandID);

    }
}
