using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;

namespace DataBaseModels
{
    [PrimaryKey("Id")]
    public class Community
    {
        public int Id { get; set; }
        public int VkId { get; set; }
        public AverangeUser AverangeUserId { get; set; }

        public Community() { }
        public Community(int vkId, AverangeUser averangeUserId)
        {
            VkId = vkId;
            AverangeUserId = averangeUserId;
        }

        public override string ToString() => $"Community {Id} with VkId {VkId}.\nAverUId: {AverangeUserId.Id}";
    }
}