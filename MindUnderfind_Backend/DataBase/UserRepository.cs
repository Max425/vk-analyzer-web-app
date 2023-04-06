using DataBaseContext;
using DataBaseModels;
using Microsoft.EntityFrameworkCore;

namespace DataBaseAPI;

public class UserRepository : IRepository<User>
{
    private Context Db { get; }
    public UserRepository(Context newDb) { Db = newDb; }
    public async Task<IEnumerable<User>?> GetList()
    {
        try
        {
            await Task.Run(() => Db.Users.ToList());
        }
        catch
        {
            Console.WriteLine($"Не удалось получить список Users.");
        }

        return null;
    }

    public async Task<User?> Get(int id)
    {
        try
        {
            await Task.Run(() => Db.Users.FirstOrDefault(x => x.VkId == id));
        }
        catch
        {
            Console.WriteLine($"Не удалось получить Community по VkId: {id}.");
        }

        return null;
    }

    public async Task CreateAsync(User user)
    {
        try
        {
            var userExists = await Db.Users.AnyAsync(c => c.VkId == user.VkId);

            if (userExists)
                throw new Exception($"user with vk id = {user.VkId} already exists");

            await Db.Users.AddAsync(user);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        await Db.SaveChangesAsync(); //?
    }

    public async Task UpdateAsync(User newUser)
    {
        try
        {
            var user = Db.Users.FirstOrDefault(x => x.VkId == newUser.VkId);

            if (user == null)
                throw new Exception($"user with vk id = {newUser.VkId} not exists");

            user.VkId = newUser.VkId;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        await Db.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        try
        {
            var delete = Db.Users.FirstOrDefault(x => x.VkId == id);

            if (delete == null)
                throw new Exception($"user with vk id = {id} already not exists =)");

            Db.Users.Remove(delete);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        await Db.SaveChangesAsync();
    }
    public async Task SaveAsync()
    {
        await Db.SaveChangesAsync();
    }
}