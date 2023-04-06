using VkNet.Enums.Filters;
using VkNet.Model;
using ModelTranslator.DTO;
using ModelTranslator.DAO;
using DataBaseAPI;
using Config;
using VkApi;


namespace Analyst;

public class AnalystWorker
{
    public ResponseDao GetData(RequestDao request)
    {
        var bbResult = CheckDb(request, out var isNeedRequestToVkApi);
        // доступ к бд пока не сделан - нужна еще одна прослойка
        // Рома, не забудь

        isNeedRequestToVkApi = true;

        var vkResult = new VkDao("None");
        if (isNeedRequestToVkApi)
            vkResult = RequestVkApi(request);

        switch (vkResult.ProcessType)
        {
            case "Community":
            case "Friends":
            case "FriendsOfFriends":
                Console.WriteLine("");
                break;
            case "None":
                Console.WriteLine("Запрос VK API не был сделан.");
                break;
            default:
                Console.WriteLine("ERROR! Неожиданный результат в swith (VkResult.ProcessType).");
                break;
        }

        var result = new ResponseDao(request.VkId);


        // result.UserArr.AddRange(VkResult.GroupUsers);
        // result.GroupArr.AddRange(VkResult.UserGroups);

        //IEnumerable<CommunityUsers> communityUsers = new();

        // foreach ()

        //result.CommunityUser.AddRange();

        return result;
    }

    private DataDao CheckDb(RequestDao requestDao, out bool needRequest)
    {
        needRequest = false;

        // check db func

        //return new DataDao(new List<int> { 1, 2, 3}, new List<int> { 4, 5, 6}, new Dictionary<int, int> { {1, 4}, {2, 4} });
        return new DataDao();
    }

    private VkDao RequestVkApi(RequestDao request)
    {
        // Create result obj
        var vkDto = new VkUserDto();

        // Autorize in VK
        var api = new VkNet.VkApi();

        api.Authorize(new ApiAuthParams
        {
            AccessToken = ConfigData.VkTokenForApi,
            Settings = Settings.All
        }) ;
        var vk = new VkApiWorker(api);
        var user = new User
        {
            Id = request.VkId
        };

        // Get Data
        /*
        vkDto.UserGroups = vk.GetUserGroups(user);

        if (request.ComVkId > 0)
        {
            vkDto.GroupUsers = vk.GetUsersByGroupId(request.ComVkId.ToString());
        }

        VkDao vkDao = vkDto.ToVkDao();
        */

        // Send to DB
        DataBase db = new();
        UserRepository apiUser = new(new DataBaseContext.Context());
        CommunityRepository apiCom = new(new DataBaseContext.Context());
        CommunityUserRepository apiComUser = new(new DataBaseContext.Context());

        /*
        db.AddList<DataBaseModels.Community>(apiCom, vkDao.UserGroups);
        db.AddList<DataBaseModels.User>(apiUser, vkDao.GroupUsers);

        db.AddRelationsList(apiComUser, new Community(request.ComVkId), vkDao.GroupUsers);


        /*vkDao.UserFri = vk.GetUserFriends(user);
        vkDao.UserFriFri = vk.GetUserFriendsAndThereFriends(user);

        */

        return new VkCommunityDao();
    }
}