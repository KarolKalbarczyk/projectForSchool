using ASP_pl.Persistance.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_pl.Extensions
{
    public static class IEnumerableExtensions
    {
        public static T Find<T>(this IEnumerable<T> seq, int id)
            where T : IWithId => seq.FirstOrDefault(x => x.Id == id);

        public static (List<T> notFulfilling, List<T> fulfilling) SplitOnPredicate<T>(this IEnumerable<T> seq, Predicate<T> predicate)
        {
            var fulfilling = new List<T>();
            var notFulfilling = new List<T>();
            foreach(var item in seq)
            {
                if (predicate(item))
                    fulfilling.Add(item);
                else
                    notFulfilling.Add(item);
            }
            return (notFulfilling, fulfilling);
        }

        public static void ForEach<T>(this IEnumerable<T> seq, Action<T> act) 
        {
            foreach (var val in seq)
                act(val);
        }

        public static int Count(this IEnumerable seq)
        {
            var count = 0;
            foreach (var _ in seq)
                count++;
            return count;
        }
    }
}
