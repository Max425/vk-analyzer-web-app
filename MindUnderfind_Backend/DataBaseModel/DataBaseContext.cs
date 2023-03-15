using System;
using Microsoft.EntityFrameworkCore;
using DataBaseModels;

namespace DataBaseContext
{
    public class Context : DbContext
    {
        public DbSet<UserFriend> UserFriend { get; set; }
        public DbSet<Community> Communities { get; set; }
        public DbSet<CommunityUser> CommunityUser { get; set; }
        public DbSet<User> Users { get; set; }

        //Создавая объект контекста автоматически пробуем подключиться к БД
        public Context()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public void ClearDatabase()
        {
            Database.EnsureDeleted();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(new Paths().paths["testPath"]);
            optionsBuilder.LogTo(message => System.Diagnostics.Debug.WriteLine(message));
        }
    }
}