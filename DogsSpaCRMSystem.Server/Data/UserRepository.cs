using DogsSpaCRMSystem.Server.Intefrace;
using DogsSpaCRMSystem.Server.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using System.Data;
using System.Linq.Expressions;

namespace DogsSpaCRMSystem.Server.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly IRepository<User> _repository;

        public UserRepository(IRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task CreateUser(User user)
        {

            await _repository.Add(user);
        }

        public async Task<IEnumerable<User>> Search(Expression<Func<User, bool>> predicate)
        {

            return await _repository.Search(predicate);
        }

        public async Task<IEnumerable<User>> SearchCred(string username, string passwordHash)
        {
            var parameters = new object[] { username, passwordHash }; // Example values
            var SPscript = "EXEC GetUserForValidation @p0, @p1";
            //return await _repository.Search(x => x.Username == username && x.PasswordHash == passwordHash);
            return _repository.ExecSP(parameters, SPscript);
        }

    }
}


