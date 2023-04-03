namespace VkApiModul;

public class VkApiWorker
{
    public VkApiWorker(VkApi api) => _api = api;
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
