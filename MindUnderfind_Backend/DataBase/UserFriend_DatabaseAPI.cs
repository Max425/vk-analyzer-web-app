using System.Linq;
using System.Numerics;
using DataBaseContext;
using DataBaseModels;

namespace DataBaseAPI
{
    public partial class DataBase
    {
        public List<UserFriend> GetListOfUserFriends()
        {
            List<UserFriend> users = new();

            using (Context db = new Context())
            {
                //забираем данные
                users = db.UserFriend.ToList();
            }

            return users;
        }

        public async Task AddUserFriends(UserFriend userFriend)
        {
            using (Context db = new Context())
            {
                var usersArr = db.UserFriend;
                var usersVkId = usersArr.Select(x => x.ChainId);

                if (!usersVkId.Contains(userFriend.ChainId))
                    usersArr.Add(userFriend);

                await db.SaveChangesAsync();
            }
        }

        public async Task ChangeUserFriends(UserFriend newUserFriend)
        {
            using (Context db = new Context())
            {
                var userFriend = db.UserFriend.FirstOrDefault(x => x.ChainId == newUserFriend.ChainId);

                if (userFriend != null)
                {
                    userFriend.VkId = newUser.VkId;
                }

                await db.SaveChangesAsync();
            }
        }

        public async Task DeleteUserFriends(int Id)
        {
            using (Context db = new Context())
            {
                var delete = db.Users.FirstOrDefault(x => x.VkId == Id);
                if (delete != null)
                    db.Users.Remove(delete);

                await db.SaveChangesAsync();
            }
        }

        public User GetUserFriends(int VkId)
        {
            User user;

            using (Context db = new Context())
            {
                user = db.Users.Find(VkId);
            }

            return user;
        }

    }
}