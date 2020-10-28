using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_pl.Account
{
    public class UserModel
    {
        [Required]
        [MinLength(5)]
        public string Login { get; set; }
        public string Password { get; set; }

    }
}
