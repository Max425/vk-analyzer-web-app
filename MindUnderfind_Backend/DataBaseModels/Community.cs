using Microsoft.EntityFrameworkCore;

namespace DataBaseModels;

[PrimaryKey("VkId")]
public class Community
{
    public long VkId { get; set; }
    public DateTime LastUpdate { get; set; }

    public List<User> Users { get; set; } = new();

    public Community(long vkId)
    {
        VkId = vkId;
        LastUpdate = DateTime.UtcNow;
    }
    public Community(long vkId, List<User> users) : this(vkId)
    {
        Users = users;
    }
}