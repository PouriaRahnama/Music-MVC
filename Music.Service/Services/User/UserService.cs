using Music.Data;
using Music.Repository;
using Music.Service.DTO_ViewModel_.Paging;
using Music.Service.DTO_ViewModel_.User;
using Music.Service.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Music.Service
{
    public class UserService : IUserService
    {

        private IRepository<User> _userRepository;
        private IRepository<UserRole> _userRoleRepository;

        public UserService(IRepository<User> _userRepository, IRepository<UserRole> userRoleRepository)
        {
          this._userRepository = _userRepository;
            _userRoleRepository = userRoleRepository;
        }

        public IEnumerable<User> GetAll()
        {
            return _userRepository.Get(null).ToList();
        }


        public User GetUserByUserId(int userId)
        {
           return  _userRepository.GetById(userId);
        }



        public void CreateUser(User user)
        {
            _userRepository.Insert(user);
        }



        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
        }



        public void DeleteUser(User user)
        {
            UpdateUser(user);
        }



        public void DeleteUser(int UserId)
        {
            var user = _userRepository.Get(u => u.Id == UserId).SingleOrDefault();
            user.IsDelete = true;
            UpdateUser(user);
        }



        public void Dispose()
        {
            _userRepository?.Dispose();
            _userRoleRepository?.Dispose();
            // اگر مخالف نال بودی دیسپوز کن
        }

        public bool IsExistUserByUserName(string userName)
        {
          return _userRepository.IsExist(u => u.UserName == userName);
        }

        public bool IsExistUserByUserName(string userName, string currenUserName)
        {
            return _userRepository.IsExist(s => s.UserName == userName && s.UserName != currenUserName);
             
        }

        public bool IsExistUserByEmail(string email)
        {
            return _userRepository.IsExist(u => u.Email == email);
        }

        public bool IsExistUserByEmail(string email, string currentEmail)
        {
            return _userRepository.IsExist(s => s.Email == email && s.Email != currentEmail);
             
        }

        public User GetUserByActiveCode(string activeCode)
        {
           return _userRepository.Get(s => s.ActiveCode == activeCode).SingleOrDefault();
        }

        public User GetUserByUsername(string userName)
        {
            return _userRepository.Get(s => s.UserName == userName).SingleOrDefault();
        }

        public User GetUserByEmail(string Email)
        {
            return _userRepository.Get(s => s.Email == Email).SingleOrDefault();
        }

        public AdminUsersDto GetUsersByFilter(AdminUsersDto filter)
        {
            var query = _userRepository.Get(null).AsQueryable().SetUsersFilter(filter);

            var count = (int)Math.Ceiling(query.Count() / (double)filter.TakeEntity);

            var pager = Pager.Build(count, filter.PageId, filter.TakeEntity);

            var users = query.OrderByDescending(s => s.Id).Paging(pager).ToList();

            return filter.SetUsers(users).SetPagingItems(pager);
        }

        public AdminEditUserDto GetUserForEdit(int userId)
        {
            var user = GetUserByUserId(userId);

            if (user == null) return null;

            return new AdminEditUserDto
            {
                Email = user.Email,
                UserId = user.Id,
                CurrentEmail = user.Email,
                UserName = user.UserName,
                CurrentUserName = user.UserName,
                IsActive = user.IsActive
            };
        }


        public bool HasUserThisPermission(string permissionName, string userName)
        {
            return _userRoleRepository.Any(s => s.Role.Name == permissionName && s.User.UserName == userName);
        }


    }
}
