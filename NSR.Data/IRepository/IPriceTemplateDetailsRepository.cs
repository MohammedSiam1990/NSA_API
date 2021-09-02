using NSR.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NSR.Data.IRepository
{
    public interface IPriceTemplateDetailsRepository
    {
        void DeletePriceTemplateDetails(int PriceTemplateID, List<PriceTemplateDetails> model);

    }
}
