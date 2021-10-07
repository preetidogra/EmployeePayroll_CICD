using System;
using System.Collections.Generic;

namespace Uppgift1_CICD
{
    public class CreateDatabase
    {
        public static Models.AdminAccount admin1 = new Models.AdminAccount("Frans Rickerbacker", "admin1", "admin1234", 3, 42300, 354503);
        //private enum CompanyRoles
        //{
        //    SeniorManager,
        //    Manager,
        //    SeniorDeveloper,
        //    JuniorDeveloper
        //}
        public static void CreateListOfUsers(Controller.VariableObject obj)
        {
            obj.UserList.Add(new Models.UserAccount( "Philip Rasmusson", "phiras001", "qasw12", 1, 42300, 594546));
            obj.UserList.Add(new Models.UserAccount( "Preeti Dogra", "predog001", "qasw12", 1, 46000, 400032));
            obj.UserList.Add(new Models.UserAccount( "Filip Engström", "fileng001", "qasw12", 2, 34900, 18245));
            obj.UserList.Add(new Models.UserAccount( "Isac Ekström", "isaeks001", "qasw12", 2, 35800, 310035));
            obj.UserList.Add(new Models.UserAccount( "Olle Rosenblad", "ollros001", "qasw12", 3, 32800, 49033));
            obj.UserList.Add(new Models.UserAccount( "Patrik Eriksson", "pateri001", "qasw12", 3, 31000, 240045));
            obj.UserList.Add(new Models.UserAccount( "Rolf Ahlander", "rolahl001", "qasw12", 3, 34600, 256022));
            obj.UserList.Add(new Models.UserAccount( "Miranda Ceder", "mirced001", "qasw12", 3, 31400, 3260435));
            obj.UserList.Add(new Models.UserAccount( "Rahul Sharma", "rahsha001", "qasw12", 4, 28000, 40203));
            obj.UserList.Add(new Models.UserAccount( "Phylia Medaar", "phymed001", "qasw12", 4, 25000, 366748));
        }  
        public static void CreateListOCompanyRoles(Controller.VariableObject obj)
        {

            obj.RoleList.Add(new Models.CompanyRole(1, "Senior Manager"));
            obj.RoleList.Add(new Models.CompanyRole(2, "Manager"));
            obj.RoleList.Add(new Models.CompanyRole(3, "Senior Developer"));
            obj.RoleList.Add(new Models.CompanyRole(4, "Junior Developer"));
        }       
    
    }
}
