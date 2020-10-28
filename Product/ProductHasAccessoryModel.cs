using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_pl.Product
{
    public class ProductHasAccessoryModel
    {
        public int Id { get; set; }
        
        [Required]
        public int AccessoryId { get; set; }
        
        [Required]
        public int ProductId { get; set; }
    }
}
