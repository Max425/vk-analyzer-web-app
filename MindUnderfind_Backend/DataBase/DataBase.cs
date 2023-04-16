using ModelTranslator;
using DataBaseModels;
using System.Runtime.CompilerServices;

namespace DataBaseAPI;

public class DataBase : IDataBase
{
    private readonly IUserRepository _userRepo;
    private readonly ICommunityRepository _comRepo;
    private readonly IComUserRepository _comUserRepo;
    public DataBase(IUserRepository userRepo,
                        ICommunityRepository comRepo,
                        IComUserRepository comUserRepo)
    {
        _userRepo = userRepo;
        _comRepo = comRepo;
        _comUserRepo = comUserRepo;
    }

    public void AddList(IEnumerable<UserDao> val)
    {
        try
        {
            if (val == null)
                throw new ArgumentNullException(nameof(val));

            var bdUsers = val.Select((user) => ConverterMU.ToDbUser(user));

            var list = _userRepo.GetList().Result;
            var set = list.Union(bdUsers);
            var general = list.Intersect(bdUsers);

            IEnumerable<User> newEl = set.Except(general);

            foreach (var el in newEl)
            {
                _userRepo.CreateAsync(el);
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public void AddList(IEnumerable<CommunityDao> val)
    {
        try
        {
            if (val == null)
                throw new ArgumentNullException(nameof(val));

            var dbComs = val.Select((user) => ConverterMU.ToDbCommunity(user));

            var list = _comRepo.GetList().Result;
            var set = list.Union(dbComs);
            var general = list.Intersect(dbComs);

            IEnumerable<Community> newEl = set.Except(general);

            foreach (var el in newEl)
            {
                _comRepo.CreateAsync(el);
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }


    public void AddRelationsList(IComUserRepository repo, CommunityDao one, List<UserDao> many)
    {
        try
        { 
            foreach (var el in many)
            {
                repo.CreateAsync(new CommunityUsers(ConverterMU.ToDbCommunity(one), ConverterMU.ToDbUser(el)));
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public void AddRelationsList(IComUserRepository repo, UserDao one, List<CommunityDao> many)
    {
        try
        {
            foreach (var el in many)
            {
                repo.CreateAsync(new CommunityUsers(ConverterMU.ToDbCommunity(el), ConverterMU.ToDbUser(one)));
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }


}