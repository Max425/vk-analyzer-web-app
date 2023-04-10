using VkNet.Enums.Filters;
using VkNet.Model;
using ModelTranslator;
using ModelTranslator.DTO;
using ModelTranslator.DAO;
using DataBaseAPI;
using Config;
using VkApi;
using VkNet.Model.Attachments;
using Microsoft.EntityFrameworkCore.Query;

using VkUser = VkNet.Model.User;
using VkGroup = VkNet.Model.Group;
using DataBaseModels;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;

namespace Analyst;

public class AnalystWorker
{
    public ResponseDao GetData(RequestDao request)
    {
        var bbResult = CheckDb(request, out var isNeedRequestToVkApi);
        // доступ к бд пока не сделан - нужна еще одна прослойка
        // Рома, не забудь

        isNeedRequestToVkApi = true;

        var vkResult = new VkDao(Process.None);
        if (isNeedRequestToVkApi)
            vkResult = RequestVkApi(request);

        switch (vkResult.ProcessType)
        {
            case Process.Community:
            case Process.Friends:
            case Process.FriendsOfFriends:
                Console.WriteLine("");
                break;
            case Process.None:
                Console.WriteLine("Запрос VK API не был сделан.");
                break;
            default:
                Console.WriteLine("ERROR! Неожиданный результат в swith (VkResult.ProcessType).");
                break;
        }

        var result = new ResponseDao(request.VkId);

        result.UserArr.AddRange(vkResult.Community.Users);

        result.GroupArr.AddRange(vkResult.User.Communities);
        foreach (var user in vkResult.Community.Users)
        {
            result.GroupArr.AddRange(user.Communities);
        }

        result.GroupArr = result.GroupArr.GroupBy(x => x.VkId).Select((y) => y.First()).ToList();

        return result;
    }

    private DataDao CheckDb(RequestDao requestDao, out bool needRequest)
    {
        needRequest = false;

        // check db func

        return new DataDao();
    }

    private VkDao RequestVkApi(RequestDao request)
    {
        var vkUserDto = new VkUserDto(request.VkId);
        var vkGroupDto = new VkGroupDto(request.VkId);

        VkDao resultDao = new VkDao();

        // Autorize in VK
        var api = new VkNet.VkApi();

        api.Authorize(new ApiAuthParams
        {
            AccessToken = ConfigData.VkTokenForApi,
            Settings = Settings.All
        }) ;
        var vk = new VkApiWorker(api);

        // Create result obj
        switch (request.ProcessType)
        {
            case Process.Community:
                resultDao = RequestVkApiAboutCommunity(request, vk);
                break;
            case Process.Friends:
                resultDao = new VkDao();
                break;
            case Process.FriendsOfFriends:
                resultDao = new VkDao();
                break;
            case Process.None:
                Console.WriteLine("Запрос VK API не был сделан.");
                break;
            default:
                Console.WriteLine("ERROR! Неожиданный результат в swith (VkResult.ProcessType).");
                break;
        }

        // Send to DB
        DataBase db = new();
        UserRepository apiUser = new(new DataBaseContext.Context());
        CommunityRepository apiCom = new(new DataBaseContext.Context());
        CommunityUserRepository apiComUser = new(new DataBaseContext.Context());

        
        db.AddList<DataBaseModels.Community>(apiCom, new List<Community>() { resultDao.Community });
        foreach(var user in resultDao.Community.Users)
            db.AddList<DataBaseModels.Community>(apiCom, user.Communities);
        db.AddList<DataBaseModels.User>(apiUser, resultDao.Community.Users);
        /*
        db.AddRelationsList(apiComUser, new Community(request.ComVkId), vkDao.GroupUsers);


        /*vkDao.UserFri = vk.GetUserFriends(user);
        vkDao.UserFriFri = vk.GetUserFriendsAndThereFriends(user);

        */

        return resultDao;
    }

    private VkDao RequestVkApiAboutCommunity(RequestDao request, VkApiWorker vk)
    {
        VkDao result = new(Process.Community);

        // Выделить в отдельный асинхронный метод запрос о пользователе
        // Task client = RequestVkClient(request.VkId, vk);
        // DataBaseModels.User userClient = new VkUserDto(request.VkId) { UserGroups = vk.GetUserGroups(new VkUser() { Id = request.VkId }) }.ToUser();

        Community community = (new VkGroupDto(request.ComVkId, vk.GetUsersByGroupId(request.ComVkId.ToString()))).ToCommunity();


        int count = 0;
            foreach (var user in community.Users)
        {
            VkUser vkUser = new VkUser() { Id = user.VkId};
            var tmp = vk.GetUserGroups(vkUser)?.ConvertAll(group => new Community(group.Id));
            if (tmp != null)
                user.Communities.AddRange(tmp);

            count++;

            if (count > 10)
                break;
        }

        result.Community = community;
        result.User = RequestVkClient(request.VkId, vk);

        return result;
    }

    private DataBaseModels.User RequestVkClient(long vkId, VkApiWorker vk)
    {
        //var clientRequest = Task.Run(() => new VkUserDto(vkId) { UserGroups = vk.GetUserGroups(new VkUser() { Id = vkId }) }.ToUser());
        // await clientRequest;

        return new VkUserDto(vkId) { UserGroups = vk.GetUserGroups(new VkUser() { Id = vkId }) }.ToUser();
    }
}