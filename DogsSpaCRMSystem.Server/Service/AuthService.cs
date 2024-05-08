using BCrypt.Net;
using DogsSpaCRMSystem.Server.Intefrace;
using DogsSpaCRMSystem.Server.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;

namespace DogsSpaCRMSystem.Server.Service
{
    public class AuthService
    {
        readonly IUserService? _userService;
        public AuthService(IUserService userService) 
        {
            if (userService != null)
            {
                _userService = userService;
            }
            else
            {
                throw new ArgumentNullException(nameof(userService));
            }
        }
        public async Task<bool> SignIn(string username, string password)
        {
             return await _userService.SearchCred(username, HashPassword(password)) != null;
        }
        public async Task SignUp(string username, string password, string firstname)
        {
            int  top = 0;
            try
            {
                top = _userService.Search(u => u.Id > 0).
                Result.OrderByDescending(u => u.Id)
                .ToList().FirstOrDefault().Id + 1;
            }
            catch (Exception ex) 
            {
                top = 1;
            }
            var user = new User
            {
                Id = top,
                Username = username,
                FirstName = firstname,
                PasswordHash = HashPassword(password) // Assuming HashPassword is a method for secure password hashing
            };
            await _userService.CreateUser(user);
        }

        // Example of password hashing method (you should implement your own secure password hashing)
        // HashPassword using bcrypt
        string HashPassword(string password)
        {
            /*
            // Generate a salt
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            */

            // Hash the password using bcrypt with the generated salt
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, SaltRevision.Revision2B);

            return hashedPassword;
        }
    }
}
