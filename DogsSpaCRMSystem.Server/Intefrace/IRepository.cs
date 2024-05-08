using System.Linq.Expressions;

namespace DogsSpaCRMSystem.Server.Intefrace
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> Search(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
        List<T> ExecSP(object[] parameters, string SPscript);
    }
}
