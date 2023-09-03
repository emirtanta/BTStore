using BTStore.Entity.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTStore.Entity.Entities.Concrete
{
    public class Product:IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad Alanı Zorunludur")]
        [Display(Name = "Adı")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Açıklama Alanı Zorunludur")]
        [Display(Name = "Açıklma")]
        [StringLength(500)]
        public string Description { get; set; }

        [Display(Name = "Logo")]
        [StringLength(1000)]
        public string Image { get; set; }

        [Display(Name = "Aktif mi?")]
        public bool IsActive { get; set; }

        [Display(Name = "Eklenme Tarihi"),ScaffoldColumn(false)]
        public DateTime? CreateDate { get; set; } = DateTime.Now;

        [Display(Name = "Fiyat")]
        public decimal? Price { get; set; }

        [Required(ErrorMessage = "Ürün Kodu Alanı Zorunludur")]
        [Display(Name = "Ürün Kodu")]
        [StringLength(50)]
        public string ProductCode { get; set; }

        [Display(Name = "Ürün Stok")]
        public int? Stock { get; set; }

        [Display(Name = "Sıra No")]
        public int? OrderNo { get; set; }

        [Display(Name = "Anasayfada mı?")]
        public bool IsHome { get; set; }



        [Display(Name = "Kategori")]
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }


        [Display(Name ="Marka")]
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }

    }
}
