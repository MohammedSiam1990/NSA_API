﻿using POS.Data.Dto.Procedure;
using POS.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.IRepository
{
    public interface IUomRepository
    {
        int SaveProcUom(Uom uom);
        List<GetUoms> GetProcUoms(int CompanyID);
    }
}
