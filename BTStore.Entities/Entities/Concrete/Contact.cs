using BTStore.Entity.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTStore.Entity.Entities.Concrete
{
    public class Contact:IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad Alanı Zorunludur")]
        [Display(Name = "Adı")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad Alanı Zorunludur")]
        [Display(Name = "Soyadı")]
        [StringLength(50)]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Email Alanı Zorunludur")]
        [Display(Name = "Email")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Telefon")]
        [StringLength(15)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Mesaj Alanı Zorunludur")]
        [Display(Name = "Mesaj")]
        [StringLength(500)]
        public string Message { get; set; }

        [Display(Name = "Eklenme Tarihi"),ScaffoldColumn(false)]
        [StringLength(50)]
        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }
}
