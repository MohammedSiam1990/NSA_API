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
        void AddRemarksTemplate(RemarksTemplate remarksTemplate);
        void UpdateRemarksTemplate(RemarksTemplate remarksTemplate);
        int ValidateNameAlreadyExist(RemarksTemplate remarksTemplate);
    }
}
