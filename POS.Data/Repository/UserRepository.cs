using POS.Data.Infrastructure;
using POS.Data.IRepository;
using Steander.Core.Entities;
using System.Linq;

namespace POS.Data.Repository
{
    public class UserRepository : Repository<ApplicationUser>, IUserRepository
    {
        public UserRepository(IDatabaseFactory databaseFactory)
        : base(databaseFactory)
        {

        }


        public ApplicationUser GetUser(int CompanyId)
        {
            var QAspNetUser = base.Table().Where(e => e.CompanyId == CompanyId).FirstOrDefault();
            base.DbContext.Dispose();
            base.DbContext = null;
            return QAspNetUser;
        }

        public void AssignRollToUser(ApplicationUser User) 
        {
            using (var context = new DataContext.PosDbContext())
            {
                context.Users.Attach(User);
                context.Entry(User).Property(x => x.RoleID).IsModified = true;
                context.SaveChanges();
            }
         }
    }
}
