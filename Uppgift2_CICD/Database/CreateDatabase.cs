using System;
using System.Collections.Generic;

namespace Uppgift1_CICD
{
    public class CreateDatabase
    {
        public static List<Models.User> CreateListOfUsers(List<Models.User> userList)
        {
            userList.Add(new Models.User(1, "Philip Rasmusson", "phiras001", "qasw12!", 1, 42300, 594546));
            userList.Add(new Models.User(2, "Preeti Dogra", "predog001", "qasw12!", 1, 46000, 400032));
            userList.Add(new Models.User(3, "Filip Engström", "fileng001", "qasw12!", 2, 34900, 18245));
            userList.Add(new Models.User(4, "Isac Ekström", "isaeks001", "qasw12!", 2, 35800, 310035));
            userList.Add(new Models.User(5, "Olle Rosenblad", "ollros001", "qasw12!", 3, 32800, 49033));
            userList.Add(new Models.User(6, "Patrik Eriksson", "pateri001", "qasw12!", 3, 31000, 240045));
            userList.Add(new Models.User(7, "Rolf Ahlander", "rolahl001", "qasw12!", 3, 34600, 256022));
            userList.Add(new Models.User(8, "Miranda Ceder", "mirced001", "qasw12!", 3, 31400, 3260435));
            userList.Add(new Models.User(9, "Rahul Sharma", "rahsha001", "qasw12!", 4, 28000, 40203));
            userList.Add(new Models.User(10, "Phylia Medaar", "phymed001", "qasw12!", 4, 25000, 366748));
            userList.Add(new Models.User(11, "Frans Rickerbacker", "admin1", "admin1234", 3, 42300, 354503));
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
    
    }
}
