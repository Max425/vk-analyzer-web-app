using DataBaseModels;

namespace DataBaseAPI;

public class DataBase
{
    public DataBase() { }
    public void AddList<T> (IRepository<T> repo, List<T> val) where T: class
    {
        IEnumerable<T> newEl = val;

        try
        {
            if (val == null)
                throw new ArgumentNullException(nameof(val));

            var list = repo.GetList().Result;
            var set = list.Union(val);
            var general = list.Intersect(val);

            newEl = set.Except(general);

            foreach (var el in newEl)
            {
                repo.CreateAsync(el);
            }

            repo.SaveAsync();
        }
        catch(Exception ex)
        {
            throw;
        }
    }

    public void AddRelationsList(IRepositoryRelationship<CommunityUsers> repo, Community one, List<User> many)
    {
        try
        { 
            foreach (var el in many)
            {
                repo.CreateAsync(new CommunityUsers(one, el));
            }

            repo.SaveAsync();
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public void AddRelationsList(IRepositoryRelationship<CommunityUsers> repo, User one, List<Community> many)
    {
        try
        {
            foreach (var el in many)
            {
                repo.CreateAsync(new CommunityUsers(el, one));
            }

            repo.SaveAsync();
        }
        catch (Exception ex)
        {
            throw;
        }
    }


}