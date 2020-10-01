using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service.IService
{
    public interface IRemarksTemplateService
    {
        string GetRemarksTemplate(int BrandID);
        bool ValidateRemarksTemplate(RemarksTemplate remarksTemplate);
        void AddRemarksTemplate(RemarksTemplate remarksTemplate);
        void UpdateRemarksTemplate(RemarksTemplate remarksTemplate);
        int ValidateNameAlreadyExist(RemarksTemplate remarksTemplate);
    }
}
