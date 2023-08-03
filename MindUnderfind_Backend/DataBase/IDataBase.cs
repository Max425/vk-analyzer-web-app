using ModelTranslator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseAPI
{
    public interface IDataBase
    {
        public void AddList(IEnumerable<UserDao> val);
        public void AddList(IEnumerable<CommunityDao> val);
        public void AddRelationsList(IComUserRepository repo, CommunityDao one, List<UserDao> many);
        public void AddRelationsList(IComUserRepository repo, UserDao one, List<CommunityDao> many);
    }
}
