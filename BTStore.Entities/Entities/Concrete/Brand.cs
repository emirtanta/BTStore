using BTStore.Entity.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTStore.Entity.Entities.Concrete
{
    public class Brand:IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Ad Alanı Gereklidir")]
        [Display(Name ="Adı")]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Açıklama")]
        [StringLength(500)]
        public string? Description { get; set; }

        [Display(Name = "Logo")]
        [StringLength(1000)]
        public string? Image { get; set; }

        [Display(Name ="Aktif mi?")]
        public bool IsActive { get; set; }

        [Display(Name ="Eklenme Tarihi"),ScaffoldColumn(false)]
        public DateTime? CreateDate { get; set; } = DateTime.Now;

        //Brand ile Product arasındaki 1'çok ilişki
        public  virtual ICollection<Product> Products { get; set; }

        public Brand()
        {
            Products = new List<Product>();
        }
    }
}
