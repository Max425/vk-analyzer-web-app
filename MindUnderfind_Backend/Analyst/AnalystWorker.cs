﻿using VkApiModul;
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
            DataDao BbResult = CheckDb(request, out isNeedRequestToVkApi);
            //доступ к бд пока не сделан - нужна еще одна прослойка
            // Рома, не забудь

            isNeedRequestToVkApi = true;

            VkDao VkResult = new VkDao();

            if (isNeedRequestToVkApi)
            {
                VkResult = RequestVkApi(request);
            }

            ResponseDao result = new ResponseDao(request.VkId);
            result.UserArr.AddRange(VkResult.GroupUsers);
            result.GroupArr.AddRange(VkResult.UserGroups);

            return result;
        }

        public DataDao CheckDb(RequestDao requestDao, out bool needRequest)
        {
            needRequest = false;

            // check db func

            return new DataDao(new List<int> { 1, 2, 3}, new List<int> { 4, 5, 6}, new Dictionary<int, int> { {1, 4}, {2, 4} });
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

            if (request.ComVkId > 0)
            {
                vkDto.GroupUsers = vk.GetUsersByGroupId(request.ComVkId.ToString());
            }

            VkDao vkDao = vkDto.ToVkDao();

            // Send to DB
            DataBase db = new DataBase();
            ApiUser apiUser = new ApiUser();
            ApiCommunity apiCom = new ApiCommunity();
            ApiGroupUser apiComUser = new ApiGroupUser();


            db.AddList<DataBaseModels.Community>(apiCom, vkDao.UserGroups);
            db.AddList<DataBaseModels.User>(apiUser, vkDao.GroupUsers);

            //db.AddRelationsList(apiComUser, new Community(request.ComVkId), vkDao.GroupUsers);


            /*vkDao.UserFri = vk.GetUserFriends(user);
            vkDao.UserFriFri = vk.GetUserFriendsAndThereFriends(user);

            */

            return vkDao;
        }




    }
}