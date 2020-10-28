using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_pl.Account
{
    [Flags]
    public enum UserRoles
    {
        User = 1,
        Admin = 2,
    }
}
