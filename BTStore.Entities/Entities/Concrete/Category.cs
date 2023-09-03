using BTStore.Entity.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTStore.Entity.Entities.Concrete
{
    public class Category:IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Kategori Adı Zorunludur")]
        [Display(Name ="Adı")]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Açıklama")]
        [StringLength(500)]
        public string? Description { get; set; }

        [Display(Name ="Logo")]
        [StringLength(1000)]
        public string? Image { get; set; }

        [Display(Name = "Aktif mi?")]
        public bool IsActive { get; set; }

        [Display(Name = "Üst Menü?")]
        public bool IsTopMenu { get; set; }

        [Display(Name ="Üst Kategori")]
        public int ParentId { get; set; }

        [Display(Name ="Sıra No")]
        public int OrderNo { get; set; }

        [Display(Name ="Eklenme Tarihi"),ScaffoldColumn(false)]
        public DateTime? CreateDate { get; set; } = DateTime.Now;

        public virtual ICollection<Product> Products { get; set; }

        public Category()
        {
            Products = new List<Product>();
        }
    }
}
