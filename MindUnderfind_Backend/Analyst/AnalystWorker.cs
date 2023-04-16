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
using System.Data;

namespace Analyst;

public class AnalystWorker : IAnalystWorker
{
    private readonly IDataBase _dataBase;
    public AnalystWorker(IDataBase dataBase)
    {
        _dataBase = dataBase;
    }

    public ResponseDao GetData(RequestDao request)
    {
        var dbResult = RequestDataBase(request, out var isNeedRequestToVkApi);
        // доступ к бд пока не сделан - нужна еще одна прослойка
        // Рома, не забудь

        isNeedRequestToVkApi = true;

        var vkResult = new VkDao(Process.None);

        try
        {
            if (isNeedRequestToVkApi)
                vkResult = RequestVkApi(request);
        }
        catch (Exception ex)
        {
            throw;
        }

        var result = new ResponseDao(request.VkId);

        if (isNeedRequestToVkApi)
        {
            result.UserArr.AddRange(vkResult.Community.Users);

            result.GroupArr.AddRange(vkResult.User.Communities);
            foreach (var user in vkResult.Community.Users)
            {
                result.GroupArr.AddRange(user.Communities);
            }
        }

        result.GroupArr = result.GroupArr.GroupBy(x => x.VkId).Select((y) => y.First()).ToList();

        return result;
    }

    public DataDao RequestDataBase(RequestDao requestDao, out bool needRequest)
    {
        needRequest = false;

        // check db func

        return new DataDao();
    }

    public VkDao RequestVkApi(RequestDao request)
    {
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
        try
        {
            /*_dataBase.AddList(new List<Community>() { resultDao.Community });
            foreach (var user in resultDao.Community.Users)
                _dataBase.AddList<DataBaseModels.Community>(apiCom, user.Communities);
            _dataBase.AddList<DataBaseModels.User>(apiUser, resultDao.Community.Users);*/
        }
        catch(Exception ex)
        {
            throw;
        }
        
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

        CommunityDao community = (new CommunityDao(request.ComVkId, vk.GetUsersByGroupId( request.ComVkId.ToString() ).ConvertAll(x => ConverterMU.ToUserDao(x)) ));


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

        // 

        result.Community = community;
        result.User = RequestVkClient(request.VkId, vk);

        return result;
    }

    /*private IEnumerable<Community> SplitForeach(IEnumerable<Community> list, Community community)
    {
        const int splitCap = 15;

        var tasks = new IEnumerable<Task<IEnumerable<Community>>>() { };
        var it = community.Users.Count / splitCap;


        for (int i = 0; i < it; i++)
        {
            tasks.Append(new Task<IEnumerable<Community>>(() => StartForeach(community.Users.Skip(splitCap * i))));
        }

        for (int j = 0; j < it; j++)
        {
            list.
        }



        return list;
    }

    private IEnumerable<Community> StartForeach(IEnumerable<DataBaseModels.User> users)
    {

    }*/

    private DataBaseModels.User RequestVkClient(long vkId, VkApiWorker vk)
    {
        //var clientRequest = Task.Run(() => new VkUserDto(vkId) { UserGroups = vk.GetUserGroups(new VkUser() { Id = vkId }) }.ToUser());
        // await clientRequest;

        return new VkUserDto(vkId) { UserGroups = vk.GetUserGroups(new VkUser() { Id = vkId }) }.ToUser();
    }

    public ResponseDao StartCalculation(RequestDao request)
    {
        ResponseDao response = new(1, 1);
        return response;
    }
}