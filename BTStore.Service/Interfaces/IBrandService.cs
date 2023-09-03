using BTStore.Entity.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTStore.Service.Interfaces
{
    public interface IBrandService:IService<Brand>
    {
        /// <summary>
        /// markayı ürünleri ile getirir
        /// </summary>
        Task<Brand> GetBrandWithProducts(int brandId);
    }
}
