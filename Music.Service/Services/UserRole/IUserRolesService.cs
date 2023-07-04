using Music.Data;
using System;


namespace Music.Service
{
    public interface IUserRolesService : IDisposable
    {
        public void Add(UserRole userRole);

        public UserRole Find(int id);

        public void Update(UserRole userRole);

        public void Delete(UserRole userRole);
    }
}
