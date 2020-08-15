using System.Threading.Tasks;
using API.Models;

namespace API.IRepositories
{
    public interface IAuthRepository
    {
        Task<UserAccount> Register(UserAccount user, string password);
        Task<UserAccount> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}