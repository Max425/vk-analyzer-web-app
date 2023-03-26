using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelTranslator.DAO
{
    public class ProcessDao
    {
        public Dictionary<int, int> RelationshipDict { get; set; }
        public List<int> ComArr { get; set; }
        public List<int> UserArr { get; set; }
        public ProcessDao(List<int> userArr, List<int> comArr, Dictionary<int, int> raltionship)
        {
            RelationshipDict = raltionship;
            ComArr = comArr;
            UserArr = userArr;
        }
    }
}
