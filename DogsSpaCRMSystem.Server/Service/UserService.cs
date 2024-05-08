using DogsSpaCRMSystem.Server.Intefrace;
using DogsSpaCRMSystem.Server.Model;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace DogsSpaCRMSystem.Server.Service
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task CreateUser(User user)
        {
             await _userRepository.CreateUser(user);
        }

        public async Task<IEnumerable<User>> Search(Expression<Func<User, bool>> predicate)
        {
            return  await _userRepository.Search(predicate);
        }

        public async Task<IEnumerable<User>> SearchCred(string username, string password)
        {
            return await _userRepository.SearchCred(username, password);

        }
    }
}