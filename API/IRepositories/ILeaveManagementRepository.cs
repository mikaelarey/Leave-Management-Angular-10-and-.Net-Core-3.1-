using System.Collections.Generic;
using System.Threading.Tasks;
using API.Models;

namespace API.IRepositories
{
    public interface ILeaveManagementRepository
    {
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         Task<bool> SaveAll();
         Task<IEnumerable<UserDetail>> GetUsers();
         Task<UserDetail> GetUser(int id);
    }
}