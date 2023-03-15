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
        public int VkId { get; set; }
        public Community() { }
        public Community(int vkId)
        {
            VkId = vkId;
        }

        public override string ToString() => $"Community VkId: {VkId}.";
    }
}