using BTStore.Data.Interfaces;
using BTStore.Entity.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTStore.Service.Interfaces
{
    public interface IService<T> : IRepository<T> where T : class, IEntity, new()
    {
    }
}
