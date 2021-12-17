using System.Linq;

namespace WebAPI.DataAccess
{
    public interface IEntityRepository<T> where T : class, new()
    {
        void Insert(T entity);
        IQueryable<T> GetAllQueryable();
    }
}
