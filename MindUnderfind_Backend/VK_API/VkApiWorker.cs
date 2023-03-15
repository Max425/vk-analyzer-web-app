using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model;
using VkNet.Model.RequestParams;

namespace ConsoleApp1;

public class VkApiWorker
{
    private VkApiWorker(VkApi api) => _api = api;
    private readonly VkApi _api;

    public List<Group>? GetUserGroups(User user)
    {
        if (user.IsClosed == true)
            return null;

        return _api.Groups.Get(new GroupsGetParams
        {
            UserId = user.Id,
            Extended = true,
            Filter = GroupsFilters.Publics,
            Fields = GroupsFields.All
        }).ToList();
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
    
    public List<User> GetUserFriendsAndThereFriends()
    {
        var friends = _api.Friends.Get(new FriendsGetParams
        {
            UserId = _api.UserId,
        }).ToList();

        foreach (var friend in friends)
        {
            friends.AddRange(GetUserFriends(friend)!);
        }
        return friends;
    }
}
