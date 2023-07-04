using Music.Service;
using System;

namespace Music.Web.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void save();

        public IUserService UserService { get; }

        public IRoleService RoleService { get; }

        public ISliderService SliderService { get; }

        public ISongService SongService { get; }

        public ISingerService SingerService { get; }

        public IUserRolesService UserRolesService { get; }
    }

}
