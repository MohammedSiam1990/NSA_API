using NSR.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NSR.Data.IRepository
{
    public interface IPriceTemplateRepository
    {
        void SavePriceTemplate(PriceTemplate model);
        int ValidateNameAlreadyExist(PriceTemplate model);

        string GetPriceTemlate(int PriceTemplateID);
    }
}
