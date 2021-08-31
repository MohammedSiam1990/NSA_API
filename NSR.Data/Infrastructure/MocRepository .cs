using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using NSR.Core.Repository.Infrastructure;
using Microsoft.EntityFrameworkCore;
using NSR.Data.DataContext;

namespace NSR.Data.Infrastructure
{
    /// <summary>
    /// <history>
    /// [Created] by AhmedMustafa: Repository for database operation
    /// </history>
    /// Class Repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MocRepository<T> : IRepository<T> where T : class
    {
        #region Initialize Pos Datacontext
        /// <summary>
        /// Initialize Pos Datacontext 
        /// </summary>
        /// <history>
        ///[Created by :]by AhmedMustafa
        /// </history>
        private PosDbContext PosDataContext;
        private UnitOfWork _UnitOfWork;
        protected PosDbContext PosDbContext
        {
            get { return PosDataContext ?? (PosDataContext = DatabaseFactory.PosGet()); }
        }

        #endregion

        protected IDatabaseFactory DatabaseFactory { get; private set; }
        protected DbSet<T> DbSet { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="databaseFactory">The database factory.</param>
        /// <history>
        /// [Created]  by AhmedMustafa: Construtor of Repository
        /// </history>
        public MocRepository(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            _UnitOfWork = new UnitOfWork(DatabaseFactory);
            DbSet = PosDbContext.Set<T>();
          
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <history>
        /// [Created]  by AhmedMustafa: For insert operation
        /// </history>
        public virtual void Add(T entity)
        {
            DbSet.Add(entity).State= EntityState.Added;
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <history>
        /// [Created]  by AhmedMustafa: For update operation
        /// </history>
        public virtual void Update(T entity)
        {

            using (var context = new PosDbContext())
            {
                context.Update(entity);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <history>
        /// [Created]  by AhmedMustafa: For delete operation
        /// </history>
        public virtual void Delete(T entity)
        {
            DbSet.Remove(entity);
        }
        public virtual void Delete(object PrimaryKey)
        {
            var EntityDeleted = DbSet.Find(PrimaryKey);
            DbSet.Remove(EntityDeleted);
        }
        /// <summary>
        /// Deletes the specified where.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <history>
        /// [Created]  by AhmedMustafa: For delete operation with specific where clause
        /// </history>
        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = DbSet.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                DbSet.Remove(obj);
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>`0.</returns>
        /// <history>
        /// [Created]  by AhmedMustafa: Fetch record based on id
        /// </history>
        public virtual T GetById(long id)
        {
            var Context = new PosDbContext();
            DbSet = Context.Set<T>();
            return DbSet.Find(id);
        }
        public virtual T GetById(int id)
        {
            var Context = new PosDbContext();
            DbSet = Context.Set<T>();
            return DbSet.Find(id);
        }
        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>`0.</returns>
        /// <history>
        /// [Created]  by AhmedMustafa: Fetch record based on id
        /// </history>
        public virtual T GetById(string id)
        {
            var Context = new PosDbContext();
            DbSet = Context.Set<T>();
            return DbSet.Find(id);
        }
        public virtual T GetById(Expression<Func<T, bool>> where)
        {
            var Context = new PosDbContext();
            DbSet = Context.Set<T>();
            return DbSet.Where(where).FirstOrDefault();
        }
        /// <summary>
        /// Gets all.
        /// </summary>
        /// <returns>IEnumerable{`0}.</returns>
        /// <history>
        /// [Created]  by AhmedMustafa: Get all record set
        /// </history>
        public virtual IEnumerable<T> GetAll()
        {
            var Context = new PosDbContext();
            DbSet = Context.Set<T>();
            return DbSet.ToList();
        }
        public virtual IQueryable<T> Table()
        {
            var Context = new PosDbContext();
            DbSet = Context.Set<T>();
            return DbSet.AsQueryable();
        }
        /// <summary>
        /// Gets the many.
        /// </summary>
        /// <param name="where">The where.</param>
        /// <returns>IEnumerable{`0}.</returns>
        /// <history>
        /// [Created]  by AhmedMustafa: Get records based on specific where clause 
        /// </history>
        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            var Context = new PosDbContext();
            DbSet = Context.Set<T>();
            return DbSet.Where(where).ToList();
        }
     
        /// <summary>
        /// Gets the many.
        /// </summary>
        /// <param name="primaryKey">The where.</param>
        /// <returns>boolean {true} if exist else {False} not exist.</returns>
        /// <history>
        /// [Created]  by AhmedMustafa: Check If Exist records 
        /// </history>
        public virtual bool Exists(long primaryKey)
        {
            var Context = new PosDbContext();
            DbSet = Context.Set<T>();
            return DbSet.Find(primaryKey) != null;
        }
        public virtual bool Exists(int primaryKey)
        {
            var Context = new PosDbContext();
            DbSet = Context.Set<T>();
            return DbSet.Find(primaryKey) != null;
        }

        /// <summary>
        /// Gets the many.
        /// </summary>
        /// <param name="predicate">The where.</param>
        /// <returns>boolean {true} if exist else {False} not exist.</returns>
        /// <history>
        /// [Created]  by AhmedMustafa: Check If Exist records 
        /// </history>
        public virtual bool Exists(Expression<Func<T, bool>> predicate)
        {
            var Context = new PosDbContext();
            DbSet = Context.Set<T>();
            var existedData = DbSet.Where(predicate);
            return existedData != null && existedData.Any();
        }


        public virtual T GetSingle(Func<T, bool> predicate)
        {
            var Context = new PosDbContext();
            DbSet = Context.Set<T>();
            return DbSet.Single<T>(predicate);
        }
        /// <summary>
        /// Gets the specified where.
        /// </summary>
        /// <param name="predicate">The where.</param>
        /// <returns>`0.</returns>
        /// <history>
        /// [Created]  by AhmedMustafa: Get First Record set based on specific where clause 
        /// </history>
        public virtual T GetFirst(Func<T, bool> predicate)
        {
            var Context = new PosDbContext();
            DbSet = Context.Set<T>();
            return DbSet.First<T>(predicate);
        }
        /// <summary>
        /// Gets the specified where.
        /// </summary>
        /// <param name="predicate">The where.</param>
        /// <returns>`0.</returns>
        /// <history>
        /// [Created]  by AhmedMustafa: Get FirstOrDefault record set based on specific where clause
        /// </history>

        public virtual T GetFirstOrDefault(Func<T, bool> predicate)
        {
            var Context = new PosDbContext();
            DbSet = Context.Set<T>();
            return DbSet.FirstOrDefault<T>(predicate);
        }



        public virtual IEnumerable<T> GetWithInclude(System.Linq.Expressions.Expression<Func<T, bool>> predicate, params string[] include)
        {
            var Context = new PosDbContext();
            DbSet = Context.Set<T>();
            IQueryable<T> query = DbSet;
            query = include.Aggregate(query, (current, inc) => current.Include(inc));
            return query.Where(predicate).ToList();
        }

        public void SaveChanges()
        {
            _UnitOfWork.Commit();
        }
    }
}
