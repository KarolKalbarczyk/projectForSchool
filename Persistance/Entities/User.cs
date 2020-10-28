using ASP_pl.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_pl.Persistance.Entities
{
    public class User : IdentityUser<int>, IEntity
    {
        int IWithId.Id => base.Id;
    }
}
