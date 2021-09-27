using System;
using System.Data.SQLite;
using System.Collections.Generic;


namespace Uppgift1_CICD
{
    class Program
    {
        static void Main(string[] args)
        {
            //var consoleMenu = new View.ConsoleMenus();

            //consoleMenu.SignInMenu();
            //consoleMenu.AdminMenu();

            List<Models.User> userList = new List<Models.User>();

            userList.Add(new Models.User(001, "Preeti Dogra", "preetiD@gmail.com", "PreetiD123!", "Software Developer", 30000, 42300));
            userList.Add(new Models.User(002, "Philip Rasmusson", "philipR@gmail.com", "PhilipR234!", "Manager", 57000, 199000));
            userList.Add(new Models.User(003, "Rico Akridge", "rikoA@gmail.com", "RikoA456@", "Software Developer", 29000, 15000));
            userList.Add(new Models.User(004, "Nakia Rivet", "NakiaR@gmail.com", "NakiaR007!", "Senior Software Engineer", 37000, 19050));
            userList.Add(new Models.User(005, "Jann Senior", "JannS@gmail.com", "JannS234@", "Senior Software Engineer", 37500, 49500));

            userList.Add(new Models.User(006, "Freya Valentina", "FreyaV@gmail.com", "FreyaV556@", "Software Engineer", 27500, 9500));
            userList.Add(new Models.User(007, "Monika Erdmann", "MonilaE@yahoo.com", "MonikaE834!", "Senior Software Engineer", 37500, 12500));
            userList.Add(new Models.User(008, "Vinzenz Alban", "VinzenzA@gmail.com", "VinzenzA997@", "Software Engineer", 29500, 21500));
            userList.Add(new Models.User(009, "Siegward Helena", "SiegwardH@gmail.com", "SiegwardH420@", "Manager", 57500, 206500));
            userList.Add(new Models.User(010, "Kai Margrit", "KaiM@gmail.com", "KaiM412!", "Senior Software Engineer", 37500, 23550));

            Console.ReadKey();

        }
    }
}
