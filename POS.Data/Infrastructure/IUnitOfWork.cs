
namespace POS.Data.Infrastructure
{
    /// <summary>
    /// <history>
    /// [Created]  by AhmedMustafa: For IRepository interface
    /// </history>
    /// Interface IUnitOfWork
    /// </summary>
    public interface IUnitOfWork
    {
        void Commit();
    }
}
