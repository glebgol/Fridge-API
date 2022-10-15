using System.Linq.Expressions;

namespace Contracts.Interfaces
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> FindAll(bool trackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges);
        T FindById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
