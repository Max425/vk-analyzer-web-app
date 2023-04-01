using DataBaseContext;
using DataBaseModels;
using Microsoft.EntityFrameworkCore;

namespace DataBaseAPI
{
    public class UserFriendRepository// : IRepositoryRelationship<UserFriend>
    {
        private Context db { get; }
        public UserFriendRepository(Context newDb) { db = newDb; }
        /*public IEnumerable<UserFriend>? GetList()
        {
            try
            {
                return db.UserFriend.ToList();
            }
            catch
            {
                Console.WriteLine($"Не удалось получить список Community.");
            }

            return null;
        }

        public UserFriend? Get(int idFirst, int idSecond)
        {
            try
            {
                return db.UserFriend.FirstOrDefault(x => x.FirstVkId == idFirst
                                                            && x.SecondVkId == idSecond);
            }
            catch
            {
                Console.WriteLine($"Не удалось получить UserFriend по VkId: {idFirst} - {idSecond}.");
            }

            return null;
        }

        public async Task CreateAsync(UserFriend userFriend)
        {
            try
            {
                var chainExists = await db.UserFriend.AnyAsync(x => x.FirstVkId == userFriend.FirstVkId
                                                            && x.SecondVkId == userFriend.SecondVkId);

                if (chainExists)
                    throw new Exception($"user-friend chain with vk id = {userFriend.FirstVkId}-{userFriend.SecondVkId} already exists");

                await db.UserFriend.AddAsync(userFriend);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            await db.SaveChangesAsync(); //?
        }

        public async Task UpdateAsync(UserFriend userFriend)
        {
            try
            {
                var chain = db.UserFriend.FirstOrDefault(x => x.FirstVkId == userFriend.FirstVkId
                                                            && x.SecondVkId == userFriend.SecondVkId);

                if (chain == null)
                    throw new Exception($"user-friend chain with vk id = {userFriend.FirstVkId}-{userFriend.SecondVkId} not exists");

                chain.FirstVkId = userFriend.FirstVkId;
                chain.SecondVkId = userFriend.SecondVkId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(UserFriend userFriend)
        {
            try
            {
                var delete = db.UserFriend.FirstOrDefault(x => x.FirstVkId == userFriend.FirstVkId
                                                            && x.SecondVkId == userFriend.SecondVkId);

                if (delete == null)
                    throw new Exception($"user-friend chain with vk id = {userFriend.FirstVkId}-{userFriend.SecondVkId} already not exists =)");

                db.UserFriend.Remove(delete);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            await db.SaveChangesAsync();
        }*/
    }
}
