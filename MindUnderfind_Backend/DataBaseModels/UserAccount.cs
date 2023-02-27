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
    public class UserAccount
    {
        public int Id { get; set; }
        public int VkId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string VisuableName { get; set; }

        public UserAccount() { }
        public UserAccount(int vkId, string login, string password, string visuablename)
        {
            VkId = vkId;
            Login = login;
            Password = password;
            VisuableName = visuablename;
        }

        public override string ToString() => $"UserAccount {Id} with VkId {VkId}.\nLogin: {Login}\nPassword: {Password}";
    }
}