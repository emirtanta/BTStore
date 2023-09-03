using BTStore.Data;
using BTStore.Data.Concrete;
using BTStore.Entity.Entities.Interfaces;
using BTStore.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTStore.Service.Repositories
{
    public class Service<T> : Repository<T>, IService<T> where T : class, IEntity, new()
    {
        public Service(DatabaseContext _context) : base(_context)
        {
            
        }
    }
}
