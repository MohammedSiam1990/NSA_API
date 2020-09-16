using POS.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private PosDbContext _PosDbContext;

        public PosDbContext PosGet()
        {
            return _PosDbContext ?? (_PosDbContext = new PosDbContext());
        }

        protected override void DisposeCore()
        {
            if (_PosDbContext != null)
                _PosDbContext.Dispose();
        }
    }
}
