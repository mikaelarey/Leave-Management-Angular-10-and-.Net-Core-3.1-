using System;
using System.Threading.Tasks;
using API.Data;
using API.IRepositories;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        public AuthRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<UserAccount> Login(string username, string password)
        {
            var user = await _context.UserAccounts.FirstOrDefaultAsync(x => x.Username == username);

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                        return false;
                }
            }

            return true;
        }

        public async Task<UserAccount> Register(UserAccount user, string password)
        {
            byte[] passwordHash, passwordSalt;

            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.UserRoleId = 1;

            await _context.UserAccounts.AddAsync(user);
            await _context.SaveChangesAsync();

            var lastInsertedId = user.UserAccountId;

            var detail = new UserDetail
            {
                UserAccountId = lastInsertedId,
                EmploymentTypeId = 1,
                DepartmentId = 1
            };

            await _context.UserDetails.AddAsync(detail);
            await _context.SaveChangesAsync();

            return user;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.UserAccounts.AnyAsync(x => x.Username == username))
                return true;

            return false;
        }

    }
}