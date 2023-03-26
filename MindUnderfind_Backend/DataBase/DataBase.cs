using DataBaseModels;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAPI
{
    public class DataBase
    {
        public DataBase() { }
        public void AddList<T> (IRepository<T> repo, List<T> val) where T: class
        {
            if (val == null)
                return;

            var list = repo.GetList();
            var set = list.Union<T>(val);
            var general = list.Intersect<T>(val);

            var newEl = set.Except<T>(general);

            foreach(var el in newEl)
            {
                repo.CreateAsync(el);
            }
        }

        public void AddRelationsList(IRepository<UserFriend> repo, User one, List<User> many)
        {
            foreach (var el in many)
            {
                repo.CreateAsync(new UserFriend(one, el));
            }
        }

        public void AddRelationsList(IRepository<CommunityUser> repo, Community one, List<User> many)
        {
            foreach (var el in many)
            {
                repo.CreateAsync(new CommunityUser(one, el));
            }
        }
        public void AddRelationsList(IRepository<CommunityUser> repo, User one, List<Community> many)
        {
            foreach (var el in many)
            {
                repo.CreateAsync(new CommunityUser(el, one));
            }
        }


    }
}
