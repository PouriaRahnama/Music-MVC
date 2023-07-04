namespace Music.Service.DTO_ViewModel_.Paging
{
    class Pager
    {
        public static BasePaging Build(int pageCount, int pageId, int take)
        {
            return new BasePaging
            {
                PageId = pageId,
                ActivePage = pageId,
                PageCount = pageCount == 0 ? 1 : pageCount,
                TakeEntity = take,
                SkipEntity = (pageId - 1) * take,
                StartPage = pageId - 3 <= 0 ? 1 : pageId - 3,
                EndPage = pageId + 3 > pageCount ? pageCount : pageId + 3
            };
        }
    }
}
