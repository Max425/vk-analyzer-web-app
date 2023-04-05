using DataBaseContext;
using DataBaseModels;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DataBaseAPI
{
    public class CommunityRepository : IRepository<Community>
    {
        private Context db { get; }
        public CommunityRepository(Context newDb) { db = newDb; }
        public async Task<IEnumerable<Community>?> GetList()
        {
            try
            {
                await Task.Run(() => db.Communities.ToList());
            }
            catch
            {
                Console.WriteLine($"Не удалось получить список Community.");
            }

            return null;
        }

        public async Task<Community?> Get(int id)
        {
            try
            {
                await Task.Run(() => db.Communities.FirstOrDefault(x => x.VkId == id));
            }
            catch
            {
                Console.WriteLine($"Не удалось получить Community по VkId: {id}.");
            }
            
            return null;
        }

        public async Task CreateAsync(Community community)
        {
            try
            {
                var communityExists = await db.Communities.AnyAsync(c => c.VkId == community.VkId);

                if (communityExists)
                    throw new Exception($"community with vk id = {community.VkId} already exists");

                await db.Communities.AddAsync(community);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task UpdateAsync(Community community)
        {
            try
            {
                var comm = await Task.Run(() => db.Communities.FirstOrDefault(x => x.VkId == community.VkId));

                if (comm == null)
                    throw new Exception($"community with vk id = {community.VkId} not exists");

                comm.VkId = community.VkId;
                comm.LastUpdate = community.LastUpdate;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var delete = await Task.Run(() => db.Communities.FirstOrDefault(x => x.VkId == id));

                if (delete == null)
                    throw new Exception($"community with vk id = {id} already not exists =)");

                db.Communities.Remove(delete);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}
