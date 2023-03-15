using System.Linq;
using System.Numerics;
using DataBaseContext;
using DataBaseModels;

namespace DataBaseAPI
{
    public partial class DataBase
    {
        public List<Community> GetListOfCommunities()
        {
            List<Community> communities = new();

            using (Context db = new Context())
            {
                //забираем данные
                communities = db.Communities.ToList();
            }

            return communities;
        }

        public async Task AddCommunity(Community community)
        {
            using (Context db = new Context())
            {
                var commsArr = db.Communities;
                var commsVkId = commsArr.Select(x => x.VkId);

                if (!commsVkId.Contains(community.VkId))
                    commsArr.Add(community);

                await db.SaveChangesAsync();
            }
        }

        public async Task ChangeCommunity(Community community)
        {
            using (Context db = new Context())
            {
                var comm = db.Communities.FirstOrDefault(x => x.VkId == community.VkId);

                if (comm != null)
                {
                    comm.VkId = community.VkId;
                }

                await db.SaveChangesAsync();
            }
        }

        public async Task DeleteCommunity(int vkid)
        {
            using (Context db = new Context())
            {
                var delete = db.Communities.FirstOrDefault(x => x.VkId == vkid);
                if (delete != null)
                    db.Communities.Remove(delete);

                await db.SaveChangesAsync();
            }
        }

        public Community GetCommunity(int VkId)
        {
            Community comm;

            using (Context db = new Context())
            {
                comm = db.Communities.Find(VkId);
            }

            return comm;
        }

    }
}