using Music.Service.DTO_ViewModel_.Paging;
using System.Linq;

namespace Music.Service.Extensions
{
    public static class PagingExtension
    {
        public static IQueryable<T> Paging<T>(this IQueryable<T> queryable, BasePaging pager)
        {
            return queryable.Skip(pager.SkipEntity).Take(pager.TakeEntity);
        }
    }

}

