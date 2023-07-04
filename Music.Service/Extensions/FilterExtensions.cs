using Music.Data;
using Music.Service.DTO_ViewModel_.User;
using System.Linq;

namespace Music.Service.Extensions
{
    public static class FilterExtensions
    {

         #region Users

        public static IQueryable<User> SetUsersFilter(this IQueryable<User> queryable, AdminUsersDto filter)
        {
            if (!string.IsNullOrEmpty(filter.FilterEmail))
            {
                queryable = queryable.Where(s => s.Email.Contains(filter.FilterEmail));
            }

            return queryable;
        }

        #endregion
    }
}
