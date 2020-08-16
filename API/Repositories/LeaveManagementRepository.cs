using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.IRepositories;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class LeaveManagementRepository : ILeaveManagementRepository
    {
        private readonly DataContext _context;
        public LeaveManagementRepository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<UserDetail> GetUser(int id)
        {
            var user = await _context.UserDetails
                .Include(p => p.Photos)
                .Include(d => d.Department)
                .Include(a => a.UserAccount.UserRole)
                .Include(e => e.EmploymentType)
                .FirstOrDefaultAsync(u => u.UserAccountId == id);
            return user;
        }

        public async Task<IEnumerable<UserDetail>> GetUsers()
        {
            var users = await _context.UserDetails
                .Include(p => p.Photos)
                .Include(d => d.Department)
                .Include(a => a.UserAccount.UserRole)
                .Include(e => e.EmploymentType)
                .ToListAsync();
            return users;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}