using Music.Service.DTO_ViewModel_.Paging;
using System.Collections.Generic;


namespace Music.Service.DTO_ViewModel_.User
{
    public class AdminUsersDto : BasePaging
    {
        public string FilterEmail { get; set; }

        public List<Data.User> Users { get; set; }

        public AdminUsersDto SetPagingItems(BasePaging paging)
        {
            PageId = paging.PageId;
            ActivePage = paging.ActivePage;
            PageCount = paging.PageCount;
            StartPage = paging.StartPage;
            EndPage = paging.EndPage;
            TakeEntity = paging.TakeEntity;
            SkipEntity = paging.SkipEntity;

            return this;
        }

        public AdminUsersDto SetUsers(List<Data.User> users)
        {         
            Users = users;

            return this;
        }



    }
}
