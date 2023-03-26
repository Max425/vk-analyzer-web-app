using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DataBaseAPI;
using DataBaseContext;

namespace DebugViewer
{/*
    public class ConsoleWorker
    {
        private int counter = 1;
        public void InitDB()
        {
            Context context = new Context();
        }

        public void StartWork()
        {
            ApiUser db = new ApiUser();
            string line = "";
            while (line != "Exit")
            {
                Console.WriteLine("Next Move (Add, Change, Delete, Get, GetList, Exit): ");
                line = Console.ReadLine();
                DoWork(db, line);
            }
        }

        private async void DoWork(IRepository<DataBaseModels.User> db, string line)
        {
            
            switch (line)
            {
                case "Add":
                    Console.WriteLine("type Pass");
                    var login = Console.ReadLine();
                    Console.WriteLine("type Pass");
                    var pass = Console.ReadLine();
                    await db.CreateAsync(new DataBaseModels.User(counter++, login, pass, "user"));
                    break;
                case "AddAdmin":
                    Console.WriteLine("type Pass");
                    var loginAdmin = Console.ReadLine();
                    Console.WriteLine("type Pass");
                    var passAdmin = Console.ReadLine();
                    await db.CreateAsync(new DataBaseModels.User(counter++, loginAdmin, passAdmin, "admin"));
                    break;
                case "AddSame":
                    await db.CreateAsync(new DataBaseModels.User(2, "pass", "rik"));
                    break;
                case "Change":
                    await db.ChangeUser(new DataBaseModels.User(1, "admin", "pass", "riker"));
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


    }*/
}