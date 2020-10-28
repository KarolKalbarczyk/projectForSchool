using ASP_pl.Extensions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_pl.Validation
{
    public class MinLengthEnumerableAttribute : ValidationAttribute
    {
        private int _minLength;
        public MinLengthEnumerableAttribute(int minLength, string errorMessage = "") : base(errorMessage)
        {
            _minLength = minLength;
        }

        public override bool IsValid(object value)
        {
            var seq = value as IEnumerable;
            return seq.Count() < _minLength;
        }
    }
}
