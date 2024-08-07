using StockManagementAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockManagementAPI.Repositories
{
    public interface IUserRepository
    {
        // GET: All users
        Task<IEnumerable<User>> GetAllAsync();
        // GET: BY ID
        Task<User> GetByIdAsync(int UserId);
        // GET: BY USERNAME
        Task<User> GetByUserNameAsync(string userName);
        // POST
        Task InsertAsync(User user);
        // UPDATE
        Task UpdateAsync(int UserId, User user);
        // DELETE   
        Task DeleteAsync(int UserId);
        // SAVE
        Task SaveAsync();
    }
}
