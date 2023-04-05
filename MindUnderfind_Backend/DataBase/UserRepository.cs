using DataBaseContext;
using DataBaseModels;
using Microsoft.EntityFrameworkCore;

namespace DataBaseAPI
{
    public class UserRepository : IRepository<User>
    {
        private Context db { get; }
        public UserRepository(Context newDb) { db = newDb; }
        public async Task<IEnumerable<User>?> GetList()
        {
            try
            {
                await new Task(new Action(db.Users.ToList()));
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
                await new Task(new Actions<User?>(db.Users.FirstOrDefault(x => x.VkId == id)));
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
                var userExists = await db.Users.AnyAsync(c => c.VkId == user.VkId);

                if (userExists)
                    throw new Exception($"user with vk id = {user.VkId} already exists");

                await db.Users.AddAsync(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            await db.SaveChangesAsync(); //?
        }

        public async Task UpdateAsync(User newUser)
        {
            try
            {
                var user = db.Users.FirstOrDefault(x => x.VkId == newUser.VkId);

                if (user == null)
                    throw new Exception($"user with vk id = {newUser.VkId} not exists");

                user.VkId = newUser.VkId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var delete = db.Users.FirstOrDefault(x => x.VkId == id);

                if (delete == null)
                    throw new Exception($"user with vk id = {id} already not exists =)");

                db.Users.Remove(delete);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            await db.SaveChangesAsync();
        }
        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}
