using VkApiModul;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet;
using VkNet.Infrastructure.Authorization.ImplicitFlow;
using ModelTranslator.DAO;
using DataBaseAPI;
using DataBaseModels;
using ModelTranslator.DTO;

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
            //result.UserArr = VkResult.GroupUsers.Select(x => x.Id).ToList();
            result.GroupArr = VkResult.UserGroups?.Select(x => x.VkId).ToList();

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
            VkDto vkDto = new VkDto();

            // Autorize in VK
            var api = new VkApi();

            api.Authorize(new ApiAuthParams
            {
                AccessToken = "vk1.a.2GtdyaMdSNiUd6Z608JC7QCSwQPtEJZPi3E07GnfzUzdospjgxktQSQ9YXPLeOLNNFa8XLYXsZeomh5gEDio8vm8tOmsBmXjtFY6Tql5UPatjBOLs1VKzrZAnxYqrYPj1i546XDbzfKMvIpg6cOW_RuZ23GU8QYkAT48t1YGJ1203AIRsxQSqfENWvlR4eVV",
                Settings = Settings.All
            });
            VkApiWorker vk = new(api);
            VkNet.Model.User user = new VkNet.Model.User();
            user.Id = request.VkId;

            // Get Data
            vkDto.UserGroups = vk.GetUserGroups(user);

            VkDao vkDao = vkDto.ToVkDao();

            // Send to DB
            DataBase db = new DataBase();
            ApiUser apiUser = new ApiUser();
            ApiCommunity apiCom = new ApiCommunity();
            db.AddList<Community>(apiCom, vkDto.ToVkDao().UserGroups);


            /*vkDao.UserFri = vk.GetUserFriends(user);
            vkDao.UserFriFri = vk.GetUserFriendsAndThereFriends(user);

            if (request.ComVkId != -1)
            {
                vkDao.GroupUsers = vk.GetUsersByGroupId(request.ComVkId.ToString());
            }*/

            return vkDao;
        }




    }
}