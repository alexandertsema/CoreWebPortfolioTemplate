using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace AlexanderTsema.Storage.Concretes.Helpers
{
    public static class QuerableExtension
    {
        /// <summary>
        /// Extension for IQearable to include all virtual members using reflections
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <returns></returns>
        public static IQueryable<T> IncludeAll<T>(this IQueryable<T> queryable) where T : class
        {
            var type = typeof(T);
            var properties = type.GetRuntimeProperties();
            return properties.Where(property => property.GetMethod.IsVirtual).Aggregate(queryable, (current, property) => current.Include(property.Name));
        }
    }
}