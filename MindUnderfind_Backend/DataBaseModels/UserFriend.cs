using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.IO;
using System.Linq;
using System.Text;

namespace DataBaseModels
{
    public class UserFriend
    {
        public int FirstVkId { get; set; }
        //public User? FirstUser { get; set; }
        public int SecondVkId { get; set; }
        //public User? SecondUser { get; set; }

        public UserFriend() { }
        public UserFriend(long id1, long id2)
        {
            FirstVkId = (int)id1;
            SecondVkId = (int)id2;
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
}