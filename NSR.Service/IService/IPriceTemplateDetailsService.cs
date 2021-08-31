using NSR.Data.Entities;
using System.Collections.Generic;

namespace NSR.Service.IService
{
    public interface IPriceTemplateDetailsService
    {
        void SavePriceTemplateDetails(int PriceTemplateID, List<PriceTemplateDetails> model);
    }
}
