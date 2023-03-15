using System.Linq;
using System.Numerics;
using DataBaseContext;
using DataBaseModels;

namespace DataBaseAPI
{
    public partial class DataBase
    {
        public List<User> GetListOfUser()
        {
            List<User> users = new();

            using (Context db = new Context())
            {
                //забираем данные
                users = db.Users.ToList();
            }

            return users;
        }

        public async Task AddUser(User user)
        {
            using (Context db = new Context())
            {
                var usersArr = db.Users;
                var usersVkId = usersArr.Select(x => x.VkId);

                if (!usersVkId.Contains(user.VkId))
                    usersArr.Add(user);

                await db.SaveChangesAsync();
            }
        }

        public async Task ChangeUser(User newUser)
        {
            using (Context db = new Context())
            {
                var user = db.Users.FirstOrDefault(x => x.VkId == newUser.VkId);

                if (user != null)
                {
                    user.VkId = newUser.VkId;
                    user.Login = newUser.Login;
                    user.Password = newUser.Password;
                }

                await db.SaveChangesAsync();
            }
        }

        public async Task DeleteUser(int Id)
        {
            using (Context db = new Context())
            {
                var delete = db.Users.FirstOrDefault(x => x.VkId == Id);
                if (delete != null)
                    db.Users.Remove(delete);

                await db.SaveChangesAsync();
            }
        }

        public User GetUser(int VkId)
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