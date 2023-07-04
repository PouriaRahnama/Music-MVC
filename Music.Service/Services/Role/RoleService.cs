using System.Collections.Generic;
using System.Linq;
using Music.Data;
using Music.Repository;

namespace Music.Service
{
    public class RoleService : IRoleService
    {
        private IRepository<Role> _roleRepository;

        public RoleService(IRepository<Role> _roleRepository)
        {
            this._roleRepository = _roleRepository;
        }

        public void Dispose()
        {
            _roleRepository?.Dispose();
        }

        public IEnumerable<Role> GetAll()
        {
            return _roleRepository.Get(null).ToList();
        }
    }
}
