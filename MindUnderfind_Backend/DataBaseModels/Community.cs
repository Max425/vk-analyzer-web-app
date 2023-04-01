using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

namespace DataBaseModels
{
    [PrimaryKey("VkId")]
    public class Community
    {
        public long VkId { get; set; }
        public DateTime LastUpdate { get; set; }

        public List<User> Users { get; set; }
        public Community(long vkId)
        {
            VkId = vkId;
            LastUpdate = DateTime.UtcNow;
        }
        public Community(long vkId, DateTime dateTime) : this(vkId)
        {
            LastUpdate = dateTime;
        }
        public override string ToString() => $"Community VkId: https://vk.com/public{VkId}";
        public string GetUrl() => $"https://vk.com/public{VkId}";
        public override bool Equals(object? obj)
        {
            if (obj is Community com) return VkId == com.VkId;
            return false;
        }
        public override int GetHashCode() => VkId.GetHashCode();
    }
}