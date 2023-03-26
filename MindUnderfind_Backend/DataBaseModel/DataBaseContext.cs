using System;
using Microsoft.EntityFrameworkCore;
using DataBaseModels;

namespace DataBaseContext
{
    public class Context : DbContext
    {
        public DbSet<UserFriend> UserFriend { get; set; } = null!;
        public DbSet<Community> Communities { get; set; } = null!;
        public DbSet<CommunityUser> CommunityUser { get; set; } = null!;
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
            //modelBuilder.Entity<CommunityUser>().HasNoKey();
            //modelBuilder.Entity<UserFriend>().HasNoKey();

            //modelBuilder.Entity<CommunityUser>().HasKey(x => new { x.CommunityId, x.UserId });

            modelBuilder.Entity<Community>()
                .HasMany(c => c.Users)
                .WithMany(s => s.Communities)
                .UsingEntity<CommunityUser>(
                j => j
                    .HasOne(pt => pt.User)
                    .WithMany(p => p.CommunityUsers)
                    .HasForeignKey(pt => pt.UserId),
                                j => j
                    .HasOne(pt => pt.Community)
                    .WithMany(t => t.CommunityUsers)
                    .HasForeignKey(pt => pt.CommunityId),
                j =>
                {
                    //j.Property(pt => pt.Mark).HasDefaultValue(3);
                    j.HasKey(x => new { x.CommunityId, x.UserId });
                    j.ToTable("CommunityUser");
                }
                );

            /*
             modelBuilder
            .Entity<Course>()
            .HasMany(c => c.Students)
            .WithMany(s => s.Courses)
            .UsingEntity<Enrollment>(
               j => j
                .HasOne(pt => pt.Student)
                .WithMany(t => t.Enrollments)
                .HasForeignKey(pt => pt.StudentId),
            j => j
                .HasOne(pt => pt.Course)
                .WithMany(p => p.Enrollments)
                .HasForeignKey(pt => pt.CourseId),
            j =>
            {
                j.Property(pt => pt.Mark).HasDefaultValue(3);
                j.HasKey(t => new { t.CourseId, t.StudentId });
                j.ToTable("Enrollments");
            });
             */
        }
    }
}