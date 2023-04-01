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
        public long FirstVkId { get; set; }
        //public User? FirstUser { get; set; }
        public long SecondVkId { get; set; }
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
}