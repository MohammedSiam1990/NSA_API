using POS.API.Helpers;
using POS.Core.Repository.Infrastructure;
using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static POS.Common.Enums;

namespace Pos.IService
{
  public  interface IBrandService
    {

        int SaveProcBrands(Brands Branch);
        List<GetBrands> GetProcBrands(int CompanyId, string ImageURL);
    }
}
