using DataBaseContext;
using DataBaseModels;
using System.Runtime.CompilerServices;

namespace DataBaseAPI
{
    public class ApiGroupUser : IRepository<CommunityUsers>
    {
        public IEnumerable<CommunityUsers> GetList()
        {
            List<CommunityUsers> cu = new();

            using (Context db = new Context())
            {
                //забираем данные
                cu = db.CommunityUsers.ToList();
            }

            return cu;
        }

        public CommunityUsers Get(int id)
        {
            CommunityUsers cu;

            using (Context db = new Context())
            {
                cu = db.CommunityUsers.Find(id.ToString());
            }

            return cu;
        }

        public async void CreateAsync(CommunityUsers CommunityUsers)
        {
            using (Context db = new Context())
            {
                var cuArr = db.CommunityUsers;
                var obj = cuArr.FirstOrDefault(x => x.UserId == CommunityUsers.UserId && x.CommunityId == CommunityUsers.CommunityId);
                //var cuIdArr = cuArr.Select((x) => $"{x.CommunityId}{x.UserId}");
                //string chain = $"{CommunityUsers.CommunityId}{CommunityUsers.UserId}";

                //if (!cuIdArr.Contains(chain))
                if (obj == null || !obj.Equals(CommunityUsers))
                    cuArr.Add(CommunityUsers);

                await db.SaveChangesAsync();
            }
        }

        public async void UpdateAsync(CommunityUsers newGroupUser)
        {
            using (Context db = new Context())
            {
                CommunityUsers? CommunityUsers = db.CommunityUsers.FirstOrDefault(x => x.CommunityId == newGroupUser.CommunityId
                                                                                    && x.UserId == newGroupUser.UserId);
                                                                                                        

                if (CommunityUsers != null)
                {
                    CommunityUsers.CommunityId = newGroupUser.CommunityId;
                    CommunityUsers.UserId = newGroupUser.UserId;
                }
                    

                await db.SaveChangesAsync();
            }
        }

        public async void DeleteAsync(int id)
        {
            using (Context db = new Context())
            {
                var delete = db.CommunityUsers.FirstOrDefault(x => $"{x.CommunityId}{x.UserId}".GetHashCode() == id);

                if (delete != null)
                    db.CommunityUsers.Remove(delete);

                await db.SaveChangesAsync();
            }
        }
    }
}
