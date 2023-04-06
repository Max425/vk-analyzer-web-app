using DataBaseContext;
using DataBaseModels;
using Microsoft.EntityFrameworkCore;

namespace DataBaseAPI;

public class CommunityUserRepository : IRepositoryRelationship<CommunityUsers>
{
    private Context Db { get; }
    public CommunityUserRepository(Context newDb) { Db = newDb; }
    public async Task<IEnumerable<CommunityUsers>?> GetList()
    {
        try
        {
            await Task.Run(() => Db.CommunityUsers.ToList());
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
            await Task.Run(() => Db.CommunityUsers.FirstOrDefault(x => x.CommunityId == idFirst
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
            var chainExists = await Db.CommunityUsers.AnyAsync(x => x.CommunityId == communityUsers.CommunityId
                                                                    && x.UserId == communityUsers.UserId);

            if (chainExists)
                throw new Exception($"community-user chain with vk id = {communityUsers.CommunityId}-{communityUsers.UserId} already exists");

            await Db.CommunityUsers.AddAsync(communityUsers);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        await Db.SaveChangesAsync(); //?
    }

    public async Task UpdateAsync(CommunityUsers communityUsers)
    {
        try
        {
            var chain = Db.CommunityUsers.FirstOrDefault(x => x.CommunityId == communityUsers.CommunityId
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

        await Db.SaveChangesAsync();
    }

    public async Task DeleteAsync(CommunityUsers communityUsers)
    {
        try
        {
            var delete = Db.CommunityUsers.FirstOrDefault(x => x.CommunityId == communityUsers.CommunityId
                                                               && x.UserId == communityUsers.UserId);

            if (delete == null)
                throw new Exception($"user-friend chain with vk id = {communityUsers.CommunityId}-{communityUsers.UserId} already not exists =)");

            Db.CommunityUsers.Remove(delete);
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