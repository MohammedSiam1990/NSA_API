using POS.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        #region Get Shams Data Context

        /// <summary>
        /// Get Pos DataContext
        /// </summary>
        /// <returns>PosDbContext</returns>
        /// <createdBy>AhmedMustafa</createdBy>
        PosDbContext PosGet();

        #endregion
    }
}
