using System.Numerics;
using DataBaseContext;
using DataBaseModels;

namespace DataBaseAPI
{
    public class DataBase
    {
        public List<UserAccount> GetListOfUser()
        {
            List<UserAccount> users = new();

            using (Context db = new Context())
            {
                //забираем данные
                users = db.UsersAccount.ToList();
            }

            return users;
        }

        public async Task AddUser(UserAccount user)
        {
            using (Context db = new Context())
            {
                db.UsersAccount.Add(user);

                await db.SaveChangesAsync();
            }
        }

        public async Task ChangeUser(UserAccount newUser)
        {
            using (Context db = new Context())
            {
                var user = db.UsersAccount.FirstOrDefault(x => x.Id == newUser.Id);

                if (user != null)
                {
                    user.VkId = newUser.VkId;
                    user.Login = newUser.Login;
                    user.Password = newUser.Password;
                    user.VisuableName = newUser.VisuableName;
                }

                await db.SaveChangesAsync();
            }
        }

        public async Task DeleteUser(int Id)
        {
            using (Context db = new Context())
            {
                var delete = db.UsersAccount.FirstOrDefault(x => x.Id == Id);
                if (delete != null)
                    db.UsersAccount.Remove(delete);

                await db.SaveChangesAsync();
            }
        }

        public UserAccount GetUser(int Id)
        {
            UserAccount user;

            using (Context db = new Context())
            {
                user = db.UsersAccount.Find(Id);
            }

            return user;
        }

    }
}