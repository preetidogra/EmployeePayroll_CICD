using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uppgift1_CICD.Controller
{
    public class VariableObject
    {
        public List<Models.UserAccount> UserList { get; set; }
        public List<Models.CompanyRole> RoleList { get; set; }
        public Models.Account User { get; set; }
        public int UserIndex { get; set; }
        public View.ConsoleMessages ConsoleMessage { get; set; }
        public Models.AdminAccount Admin { get; set; }
        public VariableObject()
        {
            ConsoleMessage = new View.ConsoleMessages();
            UserList = new List<Models.UserAccount>();
            RoleList = new List<Models.CompanyRole>();
        }
    }    
}

