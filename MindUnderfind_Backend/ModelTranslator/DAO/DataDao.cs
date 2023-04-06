using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTranslator.DAO
{
    public class DataDao
    {
        public Dictionary<long, long> RelationshipDict { get; set; }
        public List<long> ComArr { get; set; }
        public List<long> UserArr { get; set; }
        public DataDao() { }
        public DataDao(List<long> userArr, List<long> comArr, Dictionary<long, long> raltionship)
        {
            RelationshipDict = raltionship;
            ComArr = comArr;
            UserArr = userArr;
        }
    }
}
