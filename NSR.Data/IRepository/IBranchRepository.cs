
using NSR.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using static NSR.Common.Enums;

namespace NSR.Data.IRepository
{
    public interface IBranchRepository
    {

        int SaveProcBranch(Branches Branch);
        string GetProcBranches( int BrandID,string ImageURL );


    }
}