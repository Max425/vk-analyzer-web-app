using VkApiModul;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet;
using VkNet.Infrastructure.Authorization.ImplicitFlow;

namespace Analyst
{
    public class AnalystWorker
    {
        public AnalystWorker () { }
        public ResponseDao GetData (RequestDao request)
        {
            bool isNeedRequestToVkApi = false;
            ProcessDao BbResult = CheckDb(request, out isNeedRequestToVkApi);
            //доступ к бд пока не сделан - нужна еще одна прослойка
            // Рома, не забудь

            isNeedRequestToVkApi = true;

            VkDao VkResult = new VkDao();

            if (isNeedRequestToVkApi)
            {
                VkResult = RequestVkApi(request);
            }

            ResponseDao result = new ResponseDao(request.VkId);
            result.UserArr = VkResult.GroupUsers.Select(x => x.Id).ToList();

            return result;
        }

        public ProcessDao CheckDb(RequestDao requestDao, out bool needRequest)
        {
            needRequest = false;

            // check db func

            return new ProcessDao(new List<int> { 1, 2, 3}, new List<int> { 4, 5, 6}, new Dictionary<int, int> { {1, 4}, {2, 4} });
        }

        public VkDao RequestVkApi(RequestDao request)
        {
            // Create result obj
            VkDao vkDao = new VkDao();

            // Autorize in VK
            var api = new VkApi();

            api.Authorize(new ApiAuthParams
            {
                //ApplicationId = 51551860,
                AccessToken = request.VkId.ToString(),
                Settings = Settings.All
            });

            //VkApiWorker vk = new(api);
            User user = new VkNet.Model.User();
            user.Id = request.VkId;

            vkDao.UserGroups = vk.GetUserGroups(user);
            vkDao.UserFri = vk.GetUserFriends(user);
            vkDao.UserFriFri = vk.GetUserFriendsAndThereFriends();

            if (request.ComVkId != -1)
            {
                vkDao.GroupUsers = vk.GetUsersByGroupId(request.ComVkId.ToString());
            }

            // async add new data to db

            return vkDao;
        }




    }
}