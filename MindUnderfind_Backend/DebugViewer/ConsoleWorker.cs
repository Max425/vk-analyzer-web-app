using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DataBaseAPI;
using DataBaseContext;

namespace DebugViewer
{
    public class ConsoleWorker
    {
        public void InitDB()
        {
            Context context = new Context();
        }

        public void StartWork()
        {
            DataBase db = new DataBase();
            string line = "";
            while (line != "Exit")
            {
                Console.WriteLine("Next Move (Add, Change, Delete, Get, GetList, Exit): ");
                line = Console.ReadLine();
                DoWork(db, line);
            }
        }

        private async void DoWork(DataBase db, string line)
        {
            switch (line)
            {
                case "Add":
                    await db.AddUser(new DataBaseModels.UserAccount(1, "admin", "pass", "rik"));
                    break;
                case "Change":
                    await db.ChangeUser(new DataBaseModels.UserAccount(1, "admin", "pass", "riker"));
                    break;
                case "Delete":
                    await db.DeleteUser(1);
                    break;
                case "Get":
                    Console.WriteLine(db.GetUser(1));
                    break;
                case "GetList":
                    foreach (var user in db.GetListOfUser())
                        Console.WriteLine(user);
                    break;
                case "Exit":
                    break;
                default:
                    Console.WriteLine("Чё?");
                    break;
            }
        }


    }
}