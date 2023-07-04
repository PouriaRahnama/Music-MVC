using Music.Data;
using Music.Repository;

namespace Music.Service
{
    public class UserRolesService : IUserRolesService
    {
        private IRepository<UserRole> UserRolesRepository;

        public UserRolesService(IRepository<UserRole> UserRolesRepository)
        {
            this.UserRolesRepository = UserRolesRepository;
        }

        public void Add(UserRole userRole)
        {
            UserRolesRepository.Insert(userRole);
        }

        public void Delete(UserRole userRole)
        {
            UserRolesRepository.Delete(userRole);
        }

        public void Dispose()
        {
            UserRolesRepository?.Dispose();
        }

        public UserRole Find(int id)
        {
            return UserRolesRepository.GetById(id);
        }

        public void Update(UserRole userRole)
        {
            UserRolesRepository.Update(userRole);
        }
    }
}
