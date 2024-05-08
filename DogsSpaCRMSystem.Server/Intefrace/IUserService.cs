using DogsSpaCRMSystem.Server.Model;
using System.Linq.Expressions;

namespace DogsSpaCRMSystem.Server.Intefrace
{
    public interface IUserService
    {
        Task<IEnumerable<User>> SearchCred(string username, string passwordHash);
        Task CreateUser(User user);
        Task<IEnumerable<User>> Search(Expression<Func<User, bool>> predicate);
    }
}
