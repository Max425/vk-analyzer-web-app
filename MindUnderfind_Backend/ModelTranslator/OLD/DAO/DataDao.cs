namespace ModelTranslator.DAO;

public class DataDao
{
    private Dictionary<long, long> RelationshipDict { get; set; } = null!;
    private List<long> ComArr { get; set; } = null!;
    private List<long> UserArr { get; set; } = null!;
    public DataDao() { }
    public DataDao(List<long> userArr, List<long> comArr, Dictionary<long, long> relationship)
    {
        RelationshipDict = relationship;
        ComArr = comArr;
        UserArr = userArr;
    }
}