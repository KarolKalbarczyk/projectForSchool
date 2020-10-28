using ASP_pl.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_pl.Synchronization
{
    public class ErpSynchronizationModel
    {
        //[MinLengthEnumerable(1)]
        public List<SelectedErpType> ErpTypes { get; set; } = Enum.GetValues(typeof(ErpType)).Cast<ErpType>().Select(x => new SelectedErpType { Erp = x, Selected = false }).ToList();
    }

    public class SelectedErpType
    {
        public ErpType Erp { get; set; }
        public bool Selected { get; set; }
    }
}
