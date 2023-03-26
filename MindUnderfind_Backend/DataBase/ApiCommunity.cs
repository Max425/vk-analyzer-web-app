using DataBaseContext;
using DataBaseModels;

namespace DataBaseAPI
{
    public class ApiCommunity : IRepository<Community>
    {
        public IEnumerable<Community> GetList()
        {
            List<Community> communities = new();

            using (Context db = new Context())
            {
                //забираем данные
                communities = db.Communities.ToList();
            }

            return communities;
        }

        public Community Get(int id)
        {
            Community comm;

            using (Context db = new Context())
            {
                comm = db.Communities.Find(id);
            }

            return comm;
        }

        public async void CreateAsync(Community community)
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

        public async void UpdateAsync(Community community)
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

        public async void DeleteAsync(int id)
        {
            using (Context db = new Context())
            {
                var delete = db.Communities.FirstOrDefault(x => x.VkId == id);
                if (delete != null)
                    db.Communities.Remove(delete);

                await db.SaveChangesAsync();
            }
        }
    }
}
