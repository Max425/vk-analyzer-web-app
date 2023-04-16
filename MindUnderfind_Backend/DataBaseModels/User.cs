using Microsoft.EntityFrameworkCore;

namespace DataBaseModels;

[PrimaryKey("VkId")]
public class User
{
    public long VkId { get; set; }
    public bool Rights { get; set; }
    public List<Community> Communities { get; set; } = new();
    public List<User>? Friends { get; set; }
    public User(long vkId, bool rights = false)
    {
        VkId = vkId;
        Rights = rights;
    }
}