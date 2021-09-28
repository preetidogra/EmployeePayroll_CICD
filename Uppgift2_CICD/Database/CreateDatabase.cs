using System;
using System.Collections.Generic;

namespace Uppgift1_CICD
{
    public class CreateDatabase
    {
        public CreateDatabase()
        {
            
            



        }
        public static List<Models.User> CreateListOfUsers(List<Models.User> userList)
        {
            userList.Add(new Models.User(1, "Philip Rasmusson", "phiras001", "qasw12!", 1, 42300));
            userList.Add(new Models.User(2, "Preeti Dogra", "predog001", "qasw12!", 1, 46000));
            userList.Add(new Models.User(3, "Filip Engström", "fileng001", "qasw12!", 2, 34900));
            userList.Add(new Models.User(4, "Isac Ekström", "isaeks001", "qasw12!", 2, 35800));
            userList.Add(new Models.User(5, "Olle Rosenblad", "ollros001", "qasw12!", 3, 32800));
            userList.Add(new Models.User(6, "Patrik Eriksson", "pateri001", "qasw12!", 3, 31000));
            userList.Add(new Models.User(7, "Rolf Ahlander", "rolahl001", "qasw12!", 3, 34600));
            userList.Add(new Models.User(8, "Miranda Ceder", "mirced001", "qasw12!", 3, 31400));
            userList.Add(new Models.User(9, "Rahul Sharma", "rahsha001", "qasw12!", 4, 28000));
            userList.Add(new Models.User(10, "Phylia Medaar", "phymed001", "qasw12!", 4, 25000));

            return userList;
        }  
        public static List<Models.CompanyRole> CreateListOCompanyRoles(List<Models.CompanyRole> roleList)
        {
            roleList.Add(new Models.CompanyRole(1, "Senior Manager"));
            roleList.Add(new Models.CompanyRole(2, "Maganer"));
            roleList.Add(new Models.CompanyRole(3, "Senior Developer"));
            roleList.Add(new Models.CompanyRole(4, "Junior Developer"));
            return roleList;
        }
        
        public static List<Models.Account> CreateListOAccounts(List<Models.Account> accountList)
        {
            accountList.Add(new Models.Account(1, 594546));
            accountList.Add(new Models.Account(2, 354503));
            accountList.Add(new Models.Account(3, 400032));
            accountList.Add(new Models.Account(4, 18245));
            accountList.Add(new Models.Account(5, 310035));
            accountList.Add(new Models.Account(6, 49033));
            accountList.Add(new Models.Account(7, 240045));
            accountList.Add(new Models.Account(8, 256022));
            accountList.Add(new Models.Account(9, 3260435));
            accountList.Add(new Models.Account(10, 40203));
            return accountList;
        }
    }
}
