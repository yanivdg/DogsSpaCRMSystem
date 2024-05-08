using DogsSpaCRMSystem.Server.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace DogsSpaCRMSystem.Server.Intefrace
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> SearchCred(string username, string passwordHash);
        Task CreateUser(User user);
        Task<IEnumerable<User>> Search(Expression<Func<User, bool>> predicate);

    }
}
