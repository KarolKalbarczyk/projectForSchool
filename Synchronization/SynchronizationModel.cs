using ASP_pl.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_pl.Synchronization
{
    public class SynchronizationModel
    {
        public int SynchronizationId { get; set; }
        public List<string> Logs { get; set; } = new List<string>();
        public SynchronizationState State { get; set; }
        public SynchronizationStatus Status { get; set; }
        public int ProductsUpdated { get; set; }
    }
}
