using DataBaseContext;
using DataBaseModels;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace DataBaseAPI
{
    public class CommunityUserRepository : IRepositoryRelationship<CommunityUsers>
    {
        private Context db { get; }
        public CommunityUserRepository(Context newDb) { db = newDb; }
        public async Task<IEnumerable<CommunityUsers>?> GetList()
        {
            try
            {
                await Task.Run(() => db.CommunityUsers.ToList());
            }
            catch
            {
                Console.WriteLine($"Не удалось получить список communityUsers.");
            }

            return null;

        }

        public async Task<CommunityUsers?> Get(int idFirst, int idSecond)
        {
            try
            {
                await Task.Run(() => db.CommunityUsers.FirstOrDefault(x => x.CommunityId == idFirst
                                                                            && x.UserId == idSecond));
            }
            catch
            {
                Console.WriteLine($"Не удалось получить CommunityUsers по VkId: {idFirst} - {idSecond}.");
            }

            return null;
        }

        public async Task CreateAsync(CommunityUsers communityUsers)
        {
            try
            {
                var chainExists = await db.CommunityUsers.AnyAsync(x => x.CommunityId == communityUsers.CommunityId
                                                            && x.UserId == communityUsers.UserId);

                if (chainExists)
                    throw new Exception($"community-user chain with vk id = {communityUsers.CommunityId}-{communityUsers.UserId} already exists");

                await db.CommunityUsers.AddAsync(communityUsers);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            await db.SaveChangesAsync(); //?
        }

        public async Task UpdateAsync(CommunityUsers communityUsers)
        {
            try
            {
                var chain = db.CommunityUsers.FirstOrDefault(x => x.CommunityId == communityUsers.CommunityId
                                                            && x.UserId == communityUsers.UserId);

                if (chain == null)
                    throw new Exception($"user-friend chain with vk id = {communityUsers.CommunityId}-{communityUsers.UserId} not exists");

                chain.CommunityId = communityUsers.CommunityId;
                chain.UserId = communityUsers.UserId;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(CommunityUsers communityUsers)
        {
            try
            {
                var delete = db.CommunityUsers.FirstOrDefault(x => x.CommunityId == communityUsers.CommunityId
                                                            && x.UserId == communityUsers.UserId);

                if (delete == null)
                    throw new Exception($"user-friend chain with vk id = {communityUsers.CommunityId}-{communityUsers.UserId} already not exists =)");

                db.CommunityUsers.Remove(delete);
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
