using DataBaseContext;
using DataBaseModels;
using Microsoft.EntityFrameworkCore;

namespace DataBaseAPI;

public class CommunityRepository : IRepository<Community>
{
    private Context Db { get; }
    public CommunityRepository(Context newDb) { Db = newDb; }
    public async Task<IEnumerable<Community>?> GetList()
    {
        try
        {
            return await Task.Run(() => Db.Communities.ToList());
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
            return await Task.Run(() => Db.Communities.FirstOrDefault(x => x.VkId == id));
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
            var communityExists = await Db.Communities.AnyAsync(c => c.VkId == community.VkId);

            if (communityExists)
                throw new Exception($"community with vk id = {community.VkId} already exists");

            await Db.Communities.AddAsync(community);
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
            var comm = await Task.Run(() => Db.Communities.FirstOrDefault(x => x.VkId == community.VkId));

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
            var delete = await Task.Run(() => Db.Communities.FirstOrDefault(x => x.VkId == id));

            if (delete == null)
                throw new Exception($"community with vk id = {id} already not exists =)");

            Db.Communities.Remove(delete);
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public async Task SaveAsync()
    {
        await Db.SaveChangesAsync();
    }
}