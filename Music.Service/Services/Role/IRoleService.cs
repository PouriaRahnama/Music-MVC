using Music.Data;
using System;
using System.Collections.Generic;

namespace Music.Service
{
    public interface IRoleService : IDisposable
    {
        public IEnumerable<Role> GetAll();
    }
}
