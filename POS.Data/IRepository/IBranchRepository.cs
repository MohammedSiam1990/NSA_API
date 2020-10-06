
using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using static POS.Common.Enums;

namespace POS.Data.IRepository
{
    public interface IBranchRepository
    {

        int SaveProcBranch(Branches Branch);
        string GetProcBranches( int BrandID,string ImageURL );


    }
}