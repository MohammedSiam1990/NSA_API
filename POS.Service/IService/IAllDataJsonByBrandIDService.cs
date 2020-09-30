using POS.Data.Dto.Procedure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.IService
{
    public interface IAllDataJsonByBrandIDService
    {
        List<GetAllDataJsonByBrandID> GetAllDataJsonByBrandID(int BrandID, string BrandImageURL, string BranchImageURL, string ItemGroupImageURL);

    }
}
