using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using POS.API.Helpers;
using POS.Data.DataContext;
using POS.Data.Dto.Procedure;
using POS.Data.Infrastructure;
using POS.Data.IRepository;
using POS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace POS.Data.Repository
{
    public class RemarksTemplateDetailsRepository: Repository<RemarksTemplateDetails>, IRemarksTemplateDetailsRepository
    {
        public RemarksTemplateDetailsRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }

        public void DeleteRemarksTemplateDetails(int RemarksTemplateID)
        {
            try
            {
                var RemarksTemplateDetails = GetMany(e => e.RemarksTemplateId == RemarksTemplateID).ToList();
                base.DeleteRange(RemarksTemplateDetails);
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }
    }
}
