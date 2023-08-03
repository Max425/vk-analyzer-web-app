using DataBaseContext;
using DataBaseModels;
using Microsoft.EntityFrameworkCore;
using VkNet.Model;

namespace DataBaseAPI;

public class CommunityRepository : ICommunityRepository
{
    private readonly Context _context;
    public CommunityRepository(Context newDb) { _context = newDb; }
    public async Task<IEnumerable<Community>?> GetList()
    {
        try
        {
            return await _context.Communities.ToListAsync();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<Community?> Get(int id)
    {
        try
        {
            return await _context.Communities.FirstAsync(x => x.VkId == id);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task CreateAsync(Community community)
    {
        try
        {
            var communityExists = await _context.Communities.AnyAsync(c => c.VkId == community.VkId);

            if (communityExists)
                throw new Exception($"community with vk id = {community.VkId} already exists");

            await _context.Communities.AddAsync(community);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task UpdateAsync(Community community)
    {
        try
        {
            var comm = await Task.Run(() => _context.Communities.FirstOrDefault(x => x.VkId == community.VkId));

            if (comm == null)
                throw new Exception($"community with vk id = {community.VkId} not exists");

            comm.VkId = community.VkId;
            comm.LastUpdate = community.LastUpdate;

            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public async Task DeleteAsync(int id)
    {
        try
        {
            var delete = await Task.Run(() => _context.Communities.FirstOrDefault(x => x.VkId == id));

            if (delete == null)
                throw new Exception($"community with vk id = {id} already not exists =)");

            _context.Communities.Remove(delete);

            await _context.SaveChangesAsync();
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}