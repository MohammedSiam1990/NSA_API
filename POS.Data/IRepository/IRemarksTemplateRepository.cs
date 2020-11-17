using POS.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace POS.Data.IRepository
{
    public interface IRemarksTemplateRepository
    {
        string GetProcRemarksTemplate(int BrandID);
        bool ValidateRemarkTemplate(RemarksTemplate remarksTemplate);
        int AddRemarksTemplate(RemarksTemplate remarksTemplate);
        void UpdateRemarksTemplate(RemarksTemplate remarksTemplate, List<RemarksTemplateDetails> DeletRemarksTemplateDetails);
        int ValidateNameAlreadyExist(RemarksTemplate remarksTemplate);
    }
}
