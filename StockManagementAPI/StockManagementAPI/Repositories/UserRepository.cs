using StockManagementAPI.Data;
using StockManagementAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockManagementAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StockManagementDbContext _context;
        public UserRepository(StockManagementDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Id == id);
            if (user != null)
            {
                _context.User.Remove(user);
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.User.ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> GetByUserNameAsync(string userName)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Username == userName);
        }

        public async Task InsertAsync(User user)
        {
            await _context.User.AddAsync(user);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int Id, User user)
        {
            _context.User.Update(user);
        }
    }
}
