using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbCommunity = DataBaseModels.Community;
using DbUser = DataBaseModels.User;
using DbComUser = DataBaseModels.CommunityUsers;
using VkUser = VkNet.Model.User;


namespace ModelTranslator
{
    public static class ConverterMU
    {
        public static DbCommunity ToDbCommunity(CommunityDao com)
        {
            return new DbCommunity(com.VkId)
            {
                Users = com.Users,
            };
        }

        public static DbUser ToDbUser(UserDao user)
        {
            return new DbUser(user.VkId, user.Rights)
            {
                Communities = user.Communities,
                Friends = user.Friends,
            };
        }

        public static UserDao ToUserDao(DbUser user)
        {
            return new UserDao(user.VkId, user.Rights)
            {
                Communities = user.Communities,
                Friends = user.Friends,
            };
        }

        public static UserDao ToUserDao(VkUser user)
        {
            return new UserDao(user.Id);
        }

        public static CommunityDao ToCommunityDao(DbCommunity com)
        {
            return new CommunityDao(com.VkId)
            {
                Users = com.Users,
            };
        }

        public static DbComUser ToDbComUser(CommunityUserDao comUser)
        {
            return new DbComUser(comUser.CommunityId, comUser.UserId);
        }

        public static CommunityUserDao ToComUserDao(DbComUser comUser)
        {
            return new CommunityUserDao(comUser.CommunityId, comUser.UserId);
        }
    }
}
