using POS.Data.Entities;
using System.Collections.Generic;

namespace POS.Service.IService
{
    public interface IPriceTemplateDetailsService
    {
        void SavePriceTemplateDetails(int PriceTemplateID, List<PriceTemplateDetails> model);
    }
}
