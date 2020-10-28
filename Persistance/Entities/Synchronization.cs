using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_pl.Persistance.Entities
{
    public class Synchronization : IEntity
    {
        public int SynchronizationId { get; set; }
        public List<string> Logs { get; set; }
        public SynchronizationState State { get; set; }
        public SynchronizationStatus Status { get; set; }
        public int ProductsUpdated { get; set; }

        int IWithId.Id => SynchronizationId;
    }

    public class SynchronizationConfig : IEntityTypeConfiguration<Synchronization>
    {
        public void Configure(EntityTypeBuilder<Synchronization> builder)
        {
            builder.Property(s => s.Logs)
                .HasConversion(s => JsonConvert.SerializeObject(s), s => JsonConvert.DeserializeObject<List<string>>(s));
        }
    }
}
