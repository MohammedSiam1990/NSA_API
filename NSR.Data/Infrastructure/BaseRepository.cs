using NSR.Data.DataContext;
using NSR.Data.Infrastructure;

namespace NSR.Data
{
    public class BaseRepository
    {
        #region Initialize Shams Datacontext

        /// <summary>
        /// Initialize Tameeni DataContext
        /// </summary>
        /// <author>AhmedMustafa</author>
        private PosDbContext posDbContext;
        protected PosDbContext PosDbContext
        {
            get { return posDbContext ?? (posDbContext = DatabaseFactory.PosGet()); }
        }

        #endregion

        protected IDatabaseFactory DatabaseFactory { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="databaseFactory">The database factory.</param>
        /// <history>
        /// [Created] :  by Aliasgar Ghadiyali : Construtor of Repository
        /// </history>
        protected BaseRepository(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }
    }
}
