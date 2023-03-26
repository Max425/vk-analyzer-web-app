using DataBaseContext;
using DataBaseModels;

namespace DataBaseAPI
{
    public class ApiUserFriend : IRepository<UserFriend>
    {
        public IEnumerable<UserFriend> GetList()
        {
            List<UserFriend> uf = new();

            using (Context db = new Context())
            {
                //забираем данные
                uf = db.UserFriend.ToList();
            }

            return uf;
        }

        public UserFriend Get(int id)
        {
            UserFriend uf;

            using (Context db = new Context())
            {
                uf = db.UserFriend.Find(id.ToString());
            }

            return uf;
        }

        public async void CreateAsync(UserFriend userFriend)
        {
            using (Context db = new Context())
            {
                var ufArr = db.UserFriend;
                var ufIdArr = ufArr.Select(x => $"{x.FirstVkId}{x.SecondVkId}");
                string chain = $"{userFriend.FirstVkId}{userFriend.SecondVkId}";

                if (!ufIdArr.Contains(chain))
                    ufArr.Add(userFriend);

                await db.SaveChangesAsync();
            }
        }

        public async void UpdateAsync(UserFriend newUserFriend)
        {
            using (Context db = new Context())
            {
                UserFriend? userFriend = db.UserFriend.FirstOrDefault(x => x.FirstVkId == newUserFriend.FirstVkId
                                                                                    && x.SecondVkId == newUserFriend.SecondVkId);

                if (userFriend != null)
                {
                    userFriend.FirstVkId = newUserFriend.FirstVkId;
                    userFriend.SecondVkId = newUserFriend.SecondVkId;
                }
                    

                await db.SaveChangesAsync();
            }
        }

        public async void DeleteAsync(int id)
        {
            using (Context db = new Context())
            {
                var delete = db.UserFriend.FirstOrDefault(x => $"{x.FirstVkId}{x.SecondVkId}".GetHashCode() == id);

                if (delete != null)
                    db.UserFriend.Remove(delete);

                await db.SaveChangesAsync();
            }
        }
    }
}
