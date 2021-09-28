using System;
using System.Collections.Generic;
using System.Text;

namespace Uppgift1_CICD.Models
{
    public class CompanyRole
    {
        public int RoleID { get; set; }
        public string RoleName { get; set; }
    public CompanyRole(int roleID, string roleName)
        {
            this.RoleID = roleID;
            this.RoleName = roleName;
        }
    }
}
