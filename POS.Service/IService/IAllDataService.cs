using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.IService
{
    public interface IAllDataService
    {
        string GetAllData(int CompanyID,string BrandImageURL,string BranchImageURL,string ItemGroupImageURL);

    }
}
