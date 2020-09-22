﻿using POS.Data.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.IRepository
{
    public interface IMobileDataRepository
    {
        List<GetMobileData> GetMobileData(int CompanyID, string BrandImageURL, string BranchImageURL, string ItemGroupImageURL);       
    }
}
