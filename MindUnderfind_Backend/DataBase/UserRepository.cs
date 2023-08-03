using DataBaseContext;
using DataBaseModels;
using Microsoft.EntityFrameworkCore;

namespace DataBaseAPI;

public class UserRepository : IUserRepository
{
    private readonly Context _context;
    public UserRepository(Context newDb) { _context = newDb; }
    public async Task<IEnumerable<User>?> GetList()
    {
        try
        {
            return await _context.Users.ToListAsync();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<User?> Get(int id)
    {
        try
        {
            return await _context.Users.FirstAsync(x => x.VkId == id);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task CreateAsync(User user)
    {
        try
        {
            var userExists = await _context.Users.AnyAsync(c => c.VkId == user.VkId);

            if (userExists)
                throw new Exception($"user with vk id = {user.VkId} already exists");

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task UpdateAsync(User newUser)
    {
        try
        {
            var user = _context.Users.FirstOrDefault(x => x.VkId == newUser.VkId);

            if (user == null)
                throw new Exception($"user with vk id = {newUser.VkId} not exists");

            user.VkId = newUser.VkId;

            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task DeleteAsync(int id)
    {
        try
        {
            var delete = _context.Users.FirstOrDefault(x => x.VkId == id);

            if (delete == null)
                throw new Exception($"user with vk id = {id} already not exists =)");

            _context.Users.Remove(delete);

            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}