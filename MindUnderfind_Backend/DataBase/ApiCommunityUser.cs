using DataBaseContext;
using DataBaseModels;

namespace DataBaseAPI
{
    public class ApiCommunityUser : IRepository<CommunityUser>
    {
        public IEnumerable<CommunityUser> GetList()
        {
            List<CommunityUser> cu = new();

            using (Context db = new Context())
            {
                //забираем данные
                cu = db.CommunityUser.ToList();
            }

            return cu;
        }

        public CommunityUser Get(int id)
        {
            CommunityUser cu;

            using (Context db = new Context())
            {
                cu = db.CommunityUser.Find(id.ToString());
            }

            return cu;
        }

        public async void CreateAsync(CommunityUser communityUser)
        {
            using (Context db = new Context())
            {
                communityUser.ChainId = communityUser.CommunityId.ToString() + communityUser.UserAccountId.ToString();

                var cuArr = db.CommunityUser;
                var cuIdArr = cuArr.Select(x => x.ChainId);

                if (!cuIdArr.Contains(communityUser.ChainId))
                    cuArr.Add(communityUser);

                await db.SaveChangesAsync();
            }
        }

        public async void UpdateAsync(CommunityUser newCommunityUser)
        {
            using (Context db = new Context())
            {
                CommunityUser? communityUser = db.CommunityUser.FirstOrDefault(x => x.ChainId == newCommunityUser.ChainId);

                if (communityUser != null)
                    communityUser.ChainId = newCommunityUser.ChainId;

                await db.SaveChangesAsync();
            }
        }

        public async void DeleteAsync(int id)
        {
            using (Context db = new Context())
            {
                var delete = db.CommunityUser.FirstOrDefault(x => x.ChainId == id.ToString());

                if (delete != null)
                    db.CommunityUser.Remove(delete);

                await db.SaveChangesAsync();
            }
        }
    }
}
