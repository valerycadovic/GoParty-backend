using System.Linq;

namespace GoParty.Business.Core.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> Batch<T>(this IQueryable<T> self, int start, int count)
        {
            return self.Skip(start - 1).Take(count);
        }
    }
}
