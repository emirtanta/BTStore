using BTStore.Entity.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTStore.Entity.Entities.Concrete
{
    public class Slider:IEntity
    {
        public int Id { get; set; }

        [Display(Name = "Resim")]
        [StringLength(1000)]
        public string? Image { get; set; }

        [Display(Name = "Resim Linki")]
        [StringLength(1000)]
        public string? Link { get; set; }

        [Display(Name = "Başlık")]
        [StringLength(50)]
        public string Title { get; set; }

        [Display(Name = "Açıklama")]
        [StringLength(1000)]
        public string? Description { get; set; }
    }
}
