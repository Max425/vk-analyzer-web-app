using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Linq;
using System.Text;

namespace DataBaseModels
{
    [PrimaryKey("ChainId")]
    public class UserFriend
    {
        public string ChainId { get; set; }
        public int VkId1 { get; set; }
        public int VkId2 { get; set; }

        public UserFriend() { }
        public UserFriend(int id1, int id2)
        {
            ChainId = id1.ToString() + id2.ToString();
            VkId1 = id1;
            VkId2 = id2;
        }

        public override string ToString() => $"UserFriend Chain {ChainId} between: {VkId1} - {VkId2}";
    }
}