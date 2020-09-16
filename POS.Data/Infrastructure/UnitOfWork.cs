
using POS.Data.DataContext;

namespace POS.Data.Infrastructure
{
    /// <summary>
    /// Class UnitOfWork
    /// </summary>
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory _databaseFactory;
        private PosDbContext _PosDataContext;

        protected PosDbContext PosDataContext
        {
            get { return _PosDataContext ?? (_PosDataContext = _databaseFactory.PosGet()); }
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        /// <param name="databaseFactory">The database factory.</param>
        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        /// <summary>
        /// Commits this instance.
        /// </summary>
        public void Commit()
        {
            _PosDataContext.SaveChanges();
        }
    }
}
