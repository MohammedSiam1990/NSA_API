using NSR.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NSR.Data.IRepository
{
    public interface IRemarksTemplateDetailsRepository
    {
        void DeleteRemarksTemplateDetails(int RemarksTemplateID);
        List<RemarksTemplateDetails> GetRemarksTemplateDetails(int RemarksTemplateID);
    }
}
