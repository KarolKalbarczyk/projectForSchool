using ASP_pl.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_pl.Localization
{
    public class LanguageModel : IEntityModel
    {
        public int LangId { get; set; }
        public string Name { get; set; }
        int IWithId.Id => LangId;
    }
}
