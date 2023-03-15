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
    public class User
    {
        public int VkId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Rights { get; set; }

        public User() { }
        public User(int vkId, string login, string password, string rights = "user")
        {
            VkId = vkId;
            Login = login;
            Password = password;
            Rights = rights;
        }

        public override string ToString() => $"UserAccount {VkId} with VkId {VkId}.\nLogin: {Login}\nPassword: {Password}";
    }
}