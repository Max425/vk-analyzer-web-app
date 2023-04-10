public class MyUser
{
    public long VkId { get; private set; }
    public SortedSet<long> Communities { get; private set; }

    public MyUser(long vkId, SortedSet<long> communities)
    {
        VkId = vkId;
        Communities = communities;
    }
}

public class ResponseDao
{
    private MyUser _mainUser;
    private SortedSet<MyUser> _users;
    public Dictionary<long, long>? GroupAnswer { set; get; }
    public Dictionary<long, SortedSet<long>>? UsersAnswer { set; get; }

    public ResponseDao(MyUser mainUser, SortedSet<MyUser> users)
    {
        _mainUser = mainUser;
        _users = users;
    }
    
    public void RunAllInNewThread()
    {
        Task.Run(CountUsersGroupAsync);
        Task.Run(CountPopularGroup);
    }

    private async Task CountUsersGroupAsync()
    {
        UsersAnswer = new Dictionary<long, SortedSet<long>>();
        foreach (var user in _users)
        {
            var intersection = await Task.Run(() => _mainUser.Communities.Intersect(user.Communities));
            UsersAnswer.Add(user.VkId, new SortedSet<long>(intersection));
        }   
    }

    private void CountPopularGroup()
    {
        GroupAnswer = new Dictionary<long, long>();
        foreach (var groupId in _users.SelectMany(user => user.Communities))
        {
            if (GroupAnswer.ContainsKey(groupId))
            {
                GroupAnswer[groupId] += 1;
            }
            else
            {
                GroupAnswer.Add(groupId, 1);
            }
        }
    }  
}

//вот тут возвращаются данные для визуализации
//надо понять, че вообще и  в каком формате возвращать будем =)
    /*private long VkId { get; set; }
    private long ComVkId { get; set; }
    public List<User> UserArr { get; set; } = new();
    public List<Community> GroupArr { get; set; } = new();
    public List<CommunityUsers> CommunityUser { get; set; } = new();
    public ResponseDao(long vkId, long comVkId = -1)
    {
        VkId = vkId;
        ComVkId = comVkId;
    }*/