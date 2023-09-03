using BTStore.Entity.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTStore.Service.Interfaces
{
    public interface IProductService:IService<Product>
    {
        /// <summary>
        /// tüm ürünleri kategorisi ve markası ile birlikte getirir
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Product>> GetProductsCategoryByBrand();

        /// <summary>
        /// ürünü kategoriyi marka  ile getirir
        /// </summary>
        Task<Product> GetProductCategoryByBrand(int productId);
    }
}
