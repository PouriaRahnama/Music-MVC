using Music.Data;
using Music.Service.DTO_ViewModel_.User;
using System;
using System.Collections.Generic;

namespace Music.Service
{
    public interface IUserService : IDisposable
    {
        IEnumerable<User> GetAll();
        User GetUserByUserId(int userId);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
        void DeleteUser(int UserId);
        bool IsExistUserByUserName(string userName);
        bool IsExistUserByUserName(string userName, string currenUserName);
        bool IsExistUserByEmail(string email);
        bool IsExistUserByEmail(string email, string currentEmail);
        User GetUserByActiveCode(string activeCode);
        User GetUserByUsername(string userName);
        User GetUserByEmail(string Email);
        AdminUsersDto GetUsersByFilter(AdminUsersDto filter);
        AdminEditUserDto GetUserForEdit(int userId);
        bool HasUserThisPermission(string permissionName, string userName);
    }
}
