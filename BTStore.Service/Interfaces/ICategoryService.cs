using BTStore.Entity.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTStore.Service.Interfaces
{
    public interface ICategoryService:IService<Category>
    {
        /// <summary>
        /// kategoriyi ürünleri ile getirir
        /// </summary>
        Task<Category> GetCategoryWithProducts(int categoryId);
    }
}
