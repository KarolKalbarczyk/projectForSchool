using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_pl.Extensions
{
    public static class SessionExtensions
    {
        public static int GetLang(this ISession s) => s.GetInt32("lang") ?? 1;
        public static void SetLang(this ISession s, int id) => s.SetInt32("lang", id);
    }
}
