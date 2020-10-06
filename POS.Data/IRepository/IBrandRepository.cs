using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using static POS.Common.Enums;

namespace POS.Data.IRepository
{
    public interface IBrandRepository
    {
        int SaveProcBrand(Brands Branch);
        string GetProcBrand(int CompanyId, string ImageURL);
    }
}