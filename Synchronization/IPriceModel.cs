using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_pl.Synchronization
{
    public interface IPriceModel
    {
        public decimal? Price { get; }
        public string Code { get; }
    }

    public class PriceModel : IPriceModel
    {
        public decimal? Price { get; set; }

        public string Code { get; set; }
    }
}
