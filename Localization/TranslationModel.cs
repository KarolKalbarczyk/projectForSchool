using ASP_pl.Persistance;
using ASP_pl.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_pl.Localization
{
    public class TranslationModel : IEntityModel
    {
        public int TranslationId { get; set; }
        public int? OriginalId { get; set; }
        public int LangaugeId { get; set; }
        public string Text { get; set; }
        int IWithId.Id => TranslationId;
        public int TextId => OriginalId ?? TranslationId;

    }

    public static class TranslationExtensions
    {
        public static string TranslateTo(this TranslationModel t, int langaugeId, AppDbContext dbContext) =>
            t is { }
            ? dbContext
             .Translations
             .FirstOrDefault(ent => ent.TextId == t.TextId && ent.LanguageId == langaugeId)
             ?.Text ?? t.Text
            : string.Empty;
    }
}
