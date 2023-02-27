using System;
using Microsoft.EntityFrameworkCore;
using DataBaseModels;

namespace DataBaseContext
{
    public class Context : DbContext
    {
        public DbSet<AverangeUser> AverangeUsers { get; set; }
        public DbSet<Community> Communites { get; set; }
        public DbSet<CommunityUser> CommunityUsers { get; set; }
        public DbSet<UserAccount> UsersAccount { get; set; }

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