using System.Collections.Generic;
using System.Linq;

namespace GoParty.Business.Core.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Batch<T>(this IEnumerable<T> self, int start, int count)
        {
            return self.Skip(start - 1).Take(count);
        }
    }
}
