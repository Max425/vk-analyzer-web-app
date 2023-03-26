using DataBaseContext;
using DataBaseModels;

namespace DataBaseAPI
{
    public class ApiUser : IRepository<User>
    {
        public IEnumerable<User> GetList()
        {
            List<User> users = new();

            using (Context db = new Context())
            {
                //забираем данные
                users = db.Users.ToList();
            }

            return users;
        }

        public User Get(int id)
        {
            User user = new();

            using (Context db = new Context())
            {
                user = db.Users.Find(id);
            }

            return user;
        }

        public async void CreateAsync(User user)
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

        public async void UpdateAsync(User newUser)
        {
            using (Context db = new Context())
            {
                var user = db.Users.FirstOrDefault(x => x.VkId == newUser.VkId);

                if (user != null)
                {
                    user.VkId = newUser.VkId;
                }

                await db.SaveChangesAsync();
            }
        }

        public async void DeleteAsync(int id)
        {
            using (Context db = new Context())
            {
                var delete = db.Users.FirstOrDefault(x => x.VkId == id);
                if (delete != null)
                    db.Users.Remove(delete);

                await db.SaveChangesAsync();
            }
        }
    }
}
