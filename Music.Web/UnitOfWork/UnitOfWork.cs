using Music.Data;
using Music.Repository;
using Music.Repository.ApplicationContext;
using Music.Service;

namespace Music.Web.UnitOfWork
{
    public class UOW : IUnitOfWork
    {
        private Context context;
        public UOW(Context context)
        {
            this.context = context;
        }

        public UOW()
        {
        }

        private IUserService _userService;
        public IUserService UserService
        {
            get
            {
                if (_userService == null)
                {
                    _userService = new UserService(new Repository<User>(context), new Repository<UserRole>(context));
                }
                return _userService;
            }
        }


        private IRoleService roleService;
        public IRoleService RoleService
        {
            get
            {
                if (roleService == null)
                {
                    roleService = new RoleService(new Repository<Role>(context));
                }
                return roleService;
            }
        }


        private ISliderService sliderService;
        public ISliderService SliderService
        {
            get
            {
                if (sliderService == null)
                {
                    sliderService = new SliderService(new Repository<Slider>(context));
                }
                return sliderService;
            }       
        }


        private ISingerService _singerService;
        public ISingerService SingerService
        {
            get
            {
                if (_singerService == null)
                {
                    _singerService = new SingerService(new Repository<Singer>(context));
                }

                return _singerService;
            }
        }

        
        private ISongService _songService;
        public ISongService SongService
        {
            get
            {
                if (_songService == null)
                {
                    _songService = new SongService(new Repository<Song>(context),
                        new Repository<SongLike>(context),
                        new Repository<SongVisit>(context));
                }

                return _songService;
            }
        }



        private IUserRolesService _userRolesService;
        public IUserRolesService UserRolesService
        {
            get
            {
                if (_userRolesService == null)
                {
                    _userRolesService = new UserRolesService(new Repository<UserRole>(context));
                }

                return _userRolesService;
            }
        }




        public void Dispose()
        {
            context?.Dispose();
        }

        public void save()
        {
            context.SaveChanges();
        }
    }
}