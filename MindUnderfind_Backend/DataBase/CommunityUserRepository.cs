using DataBaseContext;
using DataBaseModels;
using Microsoft.EntityFrameworkCore;

namespace DataBaseAPI;

public class CommunityUserRepository : IComUserRepository
{
    private readonly Context _context;
    public CommunityUserRepository(Context newDb) { _context = newDb; }
    public async Task<IEnumerable<CommunityUsers>?> GetList()
    {
        try
        {
            return await _context.CommunityUsers.ToListAsync();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<CommunityUsers?> Get(int idFirst, int idSecond)
    {
        try
        {
            return await _context.CommunityUsers.FirstAsync(x => x.CommunityId == idFirst
                                                                       && x.UserId == idSecond);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task CreateAsync(CommunityUsers communityUsers)
    {
        try
        {
            var chainExists = await _context.CommunityUsers.AnyAsync(x => x.CommunityId == communityUsers.CommunityId
                                                                    && x.UserId == communityUsers.UserId);

            if (chainExists)
                throw new Exception($"community-user chain with vk id = {communityUsers.CommunityId}-{communityUsers.UserId} already exists");

            await _context.CommunityUsers.AddAsync(communityUsers);

            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task UpdateAsync(CommunityUsers communityUsers)
    {
        try
        {
            var chain = _context.CommunityUsers.FirstOrDefault(x => x.CommunityId == communityUsers.CommunityId
                                                              && x.UserId == communityUsers.UserId);

            if (chain == null)
                throw new Exception($"user-friend chain with vk id = {communityUsers.CommunityId}-{communityUsers.UserId} not exists");

            chain.CommunityId = communityUsers.CommunityId;
            chain.UserId = communityUsers.UserId;

            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task DeleteAsync(CommunityUsers communityUsers)
    {
        try
        {
            var delete = _context.CommunityUsers.FirstOrDefault(x => x.CommunityId == communityUsers.CommunityId
                                                               && x.UserId == communityUsers.UserId);

            if (delete == null)
                throw new Exception($"user-friend chain with vk id = {communityUsers.CommunityId}-{communityUsers.UserId} already not exists =)");

            _context.CommunityUsers.Remove(delete);

            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}