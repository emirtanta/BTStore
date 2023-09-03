using BTStore.Entity.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTStore.Entity.Entities.Concrete
{
    public class AppUser:IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad alanı gereklidir")]
        [Display(Name = "Adı")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad alanı gereklidir")]
        [Display(Name = "Soyadı")]
        [StringLength(50)]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Email alanı gereklidir")]
        [Display(Name = "Email")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon alanı gereklidir")]
        [Display(Name = "Telefon")]
        [StringLength(15)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı Alanı Gereklidir")]
        [Display(Name = "Kullanıcı Adı")]
        [StringLength(50)]
        public string Username { get; set; }

        [Required(ErrorMessage = "Şifre Alanı Gereklidir")]
        [Display(Name = "Şifre")]
        [StringLength(50)]
        public string Password { get; set; }

        [Display(Name ="Aktif mi?")]
        public bool IsActive { get; set; }

        [Display(Name ="Admin mi?")]
        public bool IsAdmin { get; set; }

        [Display(Name = "Eklenme Tarihi"), ScaffoldColumn(false)]
        public DateTime? CreateDate { get; set; } = DateTime.Now;
    }
}
