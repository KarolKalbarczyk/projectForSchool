using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_pl.Persistance.Entities
{
    public class Translation : IEntity
    {
        public int TranslationId { get; set; }
        public int? OriginalId { get; set; }
        public Translation Original { get; set; }
        public Language Language { get; set; }
        public int LanguageId { get; set; }
        public string Text { get; set; }
        public int TextId { get; private set; }

        int IWithId.Id => TranslationId;
        
    }

    public class TranslationConfig : IEntityTypeConfiguration<Translation>
    {
        public void Configure(EntityTypeBuilder<Translation> builder)
        {
            builder.Property(x => x.TextId)
                .HasComputedColumnSql("COALESCE([OriginalId], [TranslationId])");
        }
    }


}
