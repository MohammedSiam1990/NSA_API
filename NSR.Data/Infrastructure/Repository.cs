using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Linq.Expressions;
using NSR.Data.DataContext;
using NSR.Core.Repository.Infrastructure;
using Microsoft.EntityFrameworkCore;


namespace NSR.Data.Infrastructure
{
    /// <summary>
    /// <history>
    /// [Created] by AhmedMustafa: Repository for database operation
    /// </history>
    /// Class Repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Repository<T> : IRepository<T> where T : class
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
            //set {PosDbContext = value; }
        }
        //protected PosDbContext PosDbContext
        //{
        //    get { return PosDataContext = DatabaseFactory.PosGet(); }
        //}
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
        protected Repository(IDatabaseFactory databaseFactory)
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
            using (var Context = new PosDbContext())

            {
                //DbSet = Context.Set<T>();
                // DbSet.Add(entity).State = EntityState.Added;
                Context.Add(entity);
                Context.SaveChanges();
            }
        }
        public virtual void AddRange(List<T> Entities)
        {
            using (var Context = new PosDbContext())

            {
                Context.AddRange(Entities);
                Context.SaveChanges();
            }
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
        public virtual void UpdateRange(List<T> Entities)
        {
            using (var Context = new PosDbContext())

            {
                DbSet.UpdateRange(Entities);
                Context.SaveChanges();
            }
        }
        // var local = DbSet.Local.FirstOrDefault();
        //// check if local is not null 
        //  if (local != null)
        //  {
        // detach
        //   DbSet.Update(local).State = EntityState.Detached;
        //  }
        // set Modified flag in your entry
        //  PosDbContext.Entry(entity).State = EntityState.Modified;
        //  DbSet.Update(entity).State = EntityState.Modified;//This line is goes to catch error block



        /// <summary>
        /// Deletes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <history>
        /// [Created]  by AhmedMustafa: For delete operation
        /// </history>
        public virtual void Delete(T entity)
        {
            using (var Context = new PosDbContext())

            {
                DbSet.Remove(entity);
                 Context.SaveChanges();
            }
        }
        public virtual void Delete(object PrimaryKey)
        {
            using (var Context = new PosDbContext())

            {
                DbSet = Context.Set<T>();
                var EntityDeleted = DbSet.Find(PrimaryKey);
                DbSet.Remove(EntityDeleted);
                Context.SaveChanges();
            }
        }
        public virtual void DeleteRange(List<T> Entities)
        {
            using (var Context = new PosDbContext())
            {
                //var EntityDeleted = DbSet.Find(Entities);
                if (Entities != null && Entities.Count != 0)
                {    Context.RemoveRange(Entities);
                     Context.SaveChanges();
                }
                 
            }
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
            using (var Context = new PosDbContext())
            {
                DbSet = Context.Set<T>();
                return DbSet.Find(id);
            }
        }
        public virtual T GetById(int id)
        {
            using (var Context = new PosDbContext())
            {
                DbSet = Context.Set<T>();
                return DbSet.Find(id);
            }
        }

        public virtual T GetById(byte id)
        {
            using (var Context = new PosDbContext())
            {
                DbSet = Context.Set<T>();
                return DbSet.Find(id);
            }
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
            using (var Context = new PosDbContext())
            {
                DbSet = Context.Set<T>();
                return DbSet.Find(id);
            }
        }
        public virtual T GetById(Expression<Func<T, bool>> where)
        {
            using (var Context = new PosDbContext())
            {
                DbSet = Context.Set<T>();
                return DbSet.Where(where).FirstOrDefault();
            }
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
            using (var Context = new PosDbContext())
            {
                DbSet = Context.Set<T>();
                return DbSet.ToList();
            }
        }
        public PosDbContext DbContext;
        public virtual IQueryable<T> Table()
        {
              DbContext = new PosDbContext();
            
                DbSet = DbContext.Set<T>();
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
            using (var Context = new PosDbContext())
            {
                DbSet = Context.Set<T>();
                return DbSet.Where(where).ToList();
            }
        }
             public virtual IEnumerable<T> GetMany()
        {
            using (var Context = new PosDbContext())
            {
                DbSet = Context.Set<T>();
                return DbSet.ToList();
            }
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
            using (var Context = new PosDbContext())
            {
                DbSet = Context.Set<T>();
                return DbSet.Find(primaryKey) != null;
            }
        }
        public virtual bool Exists(int primaryKey)
        {
            using (var Context = new PosDbContext())
            {
                DbSet = Context.Set<T>();
                return DbSet.Find(primaryKey) != null;
            }
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
            using (var Context = new PosDbContext())
            {
                DbSet = Context.Set<T>();
                var existedData = DbSet.Where(predicate);
                return existedData != null && existedData.Any();
            }
        }


        public virtual T GetSingle(Func<T, bool> predicate)
        {
            using (var Context = new PosDbContext())
            {
                DbSet = Context.Set<T>();
                return DbSet.Single<T>(predicate);
            }
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
            using (var Context = new PosDbContext())
            {
                DbSet = Context.Set<T>();
                return DbSet.First<T>(predicate);
            }
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
            using (var Context = new PosDbContext())
            {
                DbSet = Context.Set<T>();
                return DbSet.FirstOrDefault<T>(predicate);
            }
        }



        public virtual IEnumerable<T> GetWithInclude(System.Linq.Expressions.Expression<Func<T, bool>> predicate, params string[] include)
        {
            using (var Context = new PosDbContext())
            {
                DbSet = Context.Set<T>();
                IQueryable<T> query = DbSet;
                query = include.Aggregate(query, (current, inc) => current.Include(inc));
                return query.Where(predicate).ToList();
            }
        }

        public void SaveChanges()
        {
            _UnitOfWork.Commit();
        }
    }
}
