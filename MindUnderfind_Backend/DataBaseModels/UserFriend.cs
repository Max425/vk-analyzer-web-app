namespace DataBaseModels;

public class UserFriend
{
    private long FirstVkId { get; }
    //public User? FirstUser { get; set; }
    private long SecondVkId { get; }
    //public User? SecondUser { get; set; }
    public List<User>? Friends { get; set; }
    public UserFriend(long firstVkId, long secondVkId)
    {
        FirstVkId = firstVkId;
        SecondVkId = secondVkId;
    }
    public UserFriend(User u1, User u2) : this(u1.VkId, u2.VkId) { }
    public override bool Equals(object? obj)
    {
        if (obj is UserFriend uf) return FirstVkId == uf.FirstVkId && SecondVkId == uf.SecondVkId;
        return false;
    }
    public override int GetHashCode() => $"{FirstVkId}{SecondVkId}".GetHashCode();
    public override string ToString() => $"UserFriend Chain : {FirstVkId} - {SecondVkId}";
}