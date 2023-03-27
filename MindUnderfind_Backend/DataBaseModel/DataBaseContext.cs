using System;
using Microsoft.EntityFrameworkCore;
using DataBaseModels;


namespace DataBaseContext
{
    public class Context : DbContext
    {
        public DbSet<UserFriend> UserFriend { get; set; }
        public DbSet<Community> Communities { get; set; }
        public DbSet<CommunityUsers> CommunityUsers { get; set; }
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
            //optionsBuilder.LogTo(message => System.Diagnostics.Debug.WriteLine(message));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<CommunityUsers>().HasNoKey();
            modelBuilder.Entity<UserFriend>().HasNoKey();

            modelBuilder.Entity<CommunityUsers>().HasKey(x => new { x.CommunityId, x.UserId });
            //modelBuilder.Entity<UserFriend>().HasKey(x => new { x.FirstUser, x.SecondUser });

            /*modelBuilder.Entity<User>()
                .HasMany(c => c.FirstUsers)
                .WithMany(s => s.SecondUsers)
                .UsingEntity<UserFriend>(
            j => j
                .HasOne(pt => pt.FirstUser)
                .WithMany(p => p.UserFriends)
                .HasForeignKey(pt => pt.FirstVkId),
            j => j
                .HasOne(pt => pt.SecondUser)
                .WithMany(t => t.UserFriends)
                .HasForeignKey(pt => pt.SecondVkId),
            j =>
            {
                j.HasKey(x => new { x.FirstUser, x.SecondUser });
                j.ToTable("UserFriend");
            }
            );*/

            /*
            modelBuilder.Entity<Customer>()
                    .HasMany(c => c.Products)
                    .WithMany(p => p.Customers)
                    .Map(m =>
                    {
                        // Ссылка на промежуточную таблицу
                        m.ToTable("Orders");

                        // Настройка внешних ключей промежуточной таблицы
                        m.MapLeftKey("CustomerId");
                        m.MapRightKey("ProductId");
                    });
             */
        }
    }
}