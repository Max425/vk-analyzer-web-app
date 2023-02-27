using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DataBaseModels
{
    [PrimaryKey("Id")]
    public class AverangeUser
    {
        public int Id { get; set; }
        public string HobbyJSON { get; set; }

        public AverangeUser() { }
        public AverangeUser(string hobbyjson)
        {
            HobbyJSON = hobbyjson;
        }

        public override string ToString() => $"AverangeUser {Id} with hobby: {HobbyJSON}";
    }
}