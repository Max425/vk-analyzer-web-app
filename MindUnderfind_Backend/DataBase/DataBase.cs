using DataBaseModels;

namespace DataBaseAPI;

public class DataBase
{
    public DataBase() { }
    public void AddList<T> (IRepository<T> repo, List<T> val) where T: class
    {
        if (val == null)
            throw new ArgumentNullException(nameof(val));

        var list = repo.GetList().Result;

        if (list == null)
            throw new ArgumentNullException(nameof(val));

        var set = list.Union(val);
        var general = list.Intersect(val);

        var newEl = set.Except(general);

        foreach(var el in newEl)
        {
            repo.CreateAsync(el);
        }

        repo.SaveAsync();
    }

    public void AddRelationsList(IRepositoryRelationship<CommunityUsers> repo, Community one, List<User> many)
    {
        foreach (var el in many)
        {
            repo.CreateAsync(new CommunityUsers(one, el));
        }

        repo.SaveAsync();
    }
    public void AddRelationsList(IRepositoryRelationship<CommunityUsers> repo, User one, List<Community> many)
    {
        foreach (var el in many)
        {
            repo.CreateAsync(new CommunityUsers(el, one));
        }

        repo.SaveAsync();
    }


}