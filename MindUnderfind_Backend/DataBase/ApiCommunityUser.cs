using DataBaseContext;
using DataBaseModels;
using System.Runtime.CompilerServices;

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
                var cuArr = db.CommunityUser;
                var cuIdArr = cuArr.Select((x) => $"{x.CommunityId}{x.UserId}");
                string chain = $"{communityUser.CommunityId}{communityUser.UserId}";

                if (!cuIdArr.Contains(chain))
                    cuArr.Add(communityUser);

                await db.SaveChangesAsync();
            }
        }

        public async void UpdateAsync(CommunityUser newCommunityUser)
        {
            using (Context db = new Context())
            {
                CommunityUser? communityUser = db.CommunityUser.FirstOrDefault(x => x.CommunityId == newCommunityUser.CommunityId
                                                                                    && x.UserId == newCommunityUser.UserId);
                                                                                                        

                if (communityUser != null)
                {
                    communityUser.CommunityId = newCommunityUser.CommunityId;
                    communityUser.UserId = newCommunityUser.UserId;
                }
                    

                await db.SaveChangesAsync();
            }
        }

        public async void DeleteAsync(int id)
        {
            using (Context db = new Context())
            {
                var delete = db.CommunityUser.FirstOrDefault(x => $"{x.CommunityId}{x.UserId}".GetHashCode() == id);

                if (delete != null)
                    db.CommunityUser.Remove(delete);

                await db.SaveChangesAsync();
            }
        }
    }
}
