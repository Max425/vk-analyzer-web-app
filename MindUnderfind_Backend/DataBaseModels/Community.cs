using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        public Community() { }
        public Community(long vkId)
        {
            VkId = vkId;
        }

        public override string ToString() => $"Community VkId: {VkId}.";
        public override bool Equals(object? obj)
        {
            if (obj is Community com) return VkId == com.VkId;
            return false;
        }
        public override int GetHashCode() => VkId.GetHashCode();
    }
}