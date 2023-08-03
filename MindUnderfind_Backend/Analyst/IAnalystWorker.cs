using ModelTranslator.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyst
{
    public interface IAnalystWorker
    {
        public ResponseDao GetData(RequestDao request);

        // Следующие три метода должны быть приватными, тк они вызываются внутри GetData
        // TODO: Найти синтаксис для таких методов в интерфейсе
        public ResponseDao StartCalculation(RequestDao request);
        public DataDao RequestDataBase(RequestDao request, out bool needRequest);
        public VkDao RequestVkApi(RequestDao request);

    }
}
