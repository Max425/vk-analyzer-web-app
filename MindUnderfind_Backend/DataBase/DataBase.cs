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
                throw new ArgumentNullException(nameof(val));

            IEnumerable<T>? list = repo.GetList().Result;

            if (list == null)
                throw new ArgumentNullException(nameof(val));

            IEnumerable<T> set = list.Union<T>(val);
            IEnumerable<T> general = list.Intersect<T>(val);

            IEnumerable<T> newEl = set.Except<T>(general);

            foreach(var el in newEl)
            {
                repo.CreateAsync(el);
            }

            repo.SaveAsync();
        }

        public void AddRelationsList(IRepositoryRelationship<CommunityUsers> repo, Community one, List<User> many)
        {
            foreach (var el in many)
            {
                repo.CreateAsync(new CommunityUsers(one, el));
            }

            repo.SaveAsync();
        }
        public void AddRelationsList(IRepositoryRelationship<CommunityUsers> repo, User one, List<Community> many)
        {
            foreach (var el in many)
            {
                repo.CreateAsync(new CommunityUsers(el, one));
            }

            repo.SaveAsync();
        }


    }
}
