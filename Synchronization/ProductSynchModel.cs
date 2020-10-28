using ASP_pl.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_pl.Synchronization
{
    public class ProductSynchModel
    {
        //[MinLengthEnumerable(1)]
        public List<SelectedErpType> ErpTypes { get; set; } = Enum.GetValues(typeof(ErpType)).Cast<ErpType>().Select(x => new SelectedErpType { Erp = x, Selected = false }).ToList();

        [Required]
        public int ProductId { get; set; }
    }
}
