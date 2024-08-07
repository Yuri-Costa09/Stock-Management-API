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
            try
            {
                return await _context.User.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("An error occurred while retrieving users.", ex);
            }
        }

        public async Task<User> GetByIdAsync(int id)
        {
            try
            {
                return await _context.User.FirstOrDefaultAsync(u => u.Id == id);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception($"An error occurred while retrieving the user with ID {id}.", ex);
            }
        }

        public async Task<User> GetByUserNameAsync(string userName)
        {
            try
            {
                return await _context.User.FirstOrDefaultAsync(u => u.Username == userName);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception($"An error occurred while retrieving the user with username {userName}.", ex);
            }
        }

        public async Task InsertAsync(User user)
        {
            try
            {
                await _context.User.AddAsync(user);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("An error occurred while inserting the user.", ex);
            }
        }

        public async Task SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("An error occurred while saving changes.", ex);
            }
        }

        public async Task UpdateAsync(int Id, User user)
        {
            try
            {
                _context.User.Update(user);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception($"An error occurred while updating the user with ID {Id}.", ex);
            }
        }
    }
}
