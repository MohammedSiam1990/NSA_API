using POS.Data.Infrastructure;
using POS.Data.IRepository;
using POS.Entities;
using System.Collections.Generic;
using System.Linq;

namespace POS.Data.Repository
{
    public class RemarksTemplateDetailsRepository : Repository<RemarksTemplateDetails>, IRemarksTemplateDetailsRepository
    {
        public RemarksTemplateDetailsRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }

        public void DeleteRemarksTemplateDetails(int RemarksTemplateID)
        {
            var RemarksTemplateDetails = GetMany(e => e.RemarksTemplateId == RemarksTemplateID).ToList();
            base.DeleteRange(RemarksTemplateDetails);
        }

        public List<RemarksTemplateDetails> GetRemarksTemplateDetails(int RemarksTemplateID)
        {
            return GetMany(e => e.RemarksTemplateId == RemarksTemplateID).ToList();
        }
    }
}
