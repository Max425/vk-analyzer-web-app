using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DataBaseContext
{
    public class Paths
    {
        //Перед началом работы вставьте пароль
        //В конце работы перед отправкой в облако - удали
        public Dictionary<string, string> paths = new Dictionary<string, string>()
        { { "testPath", "Host=localhost;Port=5432;Database=test_for_web;Username=postgres;Password=-" }, };
    }
}