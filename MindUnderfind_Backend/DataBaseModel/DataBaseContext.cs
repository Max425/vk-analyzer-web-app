using System;
using Microsoft.EntityFrameworkCore;
using DataBaseModels;
using Config;


namespace DataBaseContext
{
    public class Context : DbContext
    {
        //public DbSet<UserFriend> UserFriend { get; set; }
        public DbSet<Community> Communities { get; set; }
        public DbSet<CommunityUsers> CommunityUsers { get; set; }
        public DbSet<User> Users { get; set; }

        //Создавая объект контекста автоматически пробуем подключиться к БД
        public Context()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public void ClearDatabase()
        {
            Database.EnsureDeleted();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(ConfigData.DataBaseAcceesString);
            //optionsBuilder.LogTo(message => System.Diagnostics.Debug.WriteLine(message));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<CommunityUsers>().HasNoKey();
            modelBuilder.Entity<UserFriend>().HasNoKey();

            modelBuilder.Entity<CommunityUsers>().HasKey(x => new { x.CommunityId, x.UserId });

            modelBuilder.Entity<User>().HasMany(u => u.Communities);
            modelBuilder.Entity<Community>().HasMany(u => u.Users);

            modelBuilder.Entity<User>().HasMany(u => u.Friends);
            modelBuilder.Entity<User>().HasMany(u => u.Friends);
        }
    }
}