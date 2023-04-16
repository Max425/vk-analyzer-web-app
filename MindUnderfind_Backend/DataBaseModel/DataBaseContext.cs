using Microsoft.EntityFrameworkCore;
using DataBaseModels;
using Config;


namespace DataBaseContext;

public sealed class Context : DbContext
{
    //public DbSet<UserFriend> UserFriend { get; set; }
    public DbSet<Community> Communities { get; set; } = null!;
    public DbSet<CommunityUsers> CommunityUsers { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;

    //Создавая объект контекста автоматически пробуем подключиться к БД
    public Context()
    {
        // Database.EnsureDeleted();
        Database.EnsureCreated();
    }

    public void ClearDatabase()
    {
        Database.EnsureDeleted();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(ConfigData.DataBaseAccessString);
        //optionsBuilder.LogTo(message => System.Diagnostics.Debug.WriteLine(message));
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CommunityUsers>().HasKey(x => new { x.CommunityId, x.UserId });

        modelBuilder.Entity<User>().HasMany(u => u.Communities);
        modelBuilder.Entity<Community>().HasMany(u => u.Users);
    }
}