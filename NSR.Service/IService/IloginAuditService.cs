using NSR.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSR.Service.IService
{
    public interface IloginAuditService
    {
        void SaveLoginAudit(LoginAudit model);
    }
}
