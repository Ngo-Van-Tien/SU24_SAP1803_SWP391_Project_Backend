using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Constans
{
    public static class UserRolesConstant
    {
        public const string Admin = "Admin";
        public const string Staff = "Staff";
        public const string Customer = "Customer";
        public const string AdminOrStaff = Admin + "," + Staff;
    }
}
