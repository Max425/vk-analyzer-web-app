using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace VkApi;

public class VkApiWorker
{
    public VkApiWorker(VkNet.VkApi api) => _api = api;
    private readonly VkNet.VkApi _api;

    public List<Group>? GetUserGroups(User user)
    {
        if (user.IsClosed == true)
            return null;

        List<Group>? tmp = null;

        try
        {
            tmp = _api.Groups.Get(new GroupsGetParams
            {
                UserId = user.Id,
                Extended = true,
                Filter = GroupsFilters.Publics,
                Fields = GroupsFields.All
            }).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }

        return tmp;
    }
    // Метод нужно доработать, т.к. возвращает только 500-600 участников сообщества
    public List<User> GetUsersByGroupId(string groupId)
    {
        return _api.Groups.GetMembers(new GroupsGetMembersParams
        {
            GroupId = groupId,
            Fields = UsersFields.All
        }).ToList();
    }

    public List<User>? GetUserFriends(User user)
    {
        if (user.IsClosed == true)
            return null;

        return _api.Friends.Get(new FriendsGetParams
        {
            UserId = user.Id,
        }).ToList();
    }

    public List<User> GetUserFriendsAndThereFriends(User user)
    {
        var friends = _api.Friends.Get(new FriendsGetParams
        {
            UserId = user.Id,
        }).ToList();

        var result = new List<User>(friends);

        foreach (var friend in friends)
        {
            result.AddRange(GetUserFriends(friend)!);
        }
        return result;
    }
}
