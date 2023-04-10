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
    public override string ToString() => $"Community VkId: https://vk.com/public{VkId}";
    public string GetUrl() => $"https://vk.com/public{VkId}";
    public override bool Equals(object? obj)
    {
        return obj is Community com && VkId == com.VkId;
    }
    public override int GetHashCode() => VkId.GetHashCode();
}