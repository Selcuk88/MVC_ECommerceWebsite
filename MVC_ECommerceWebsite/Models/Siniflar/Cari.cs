using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Management;

namespace MVC_ECommerceWebsite.Models.Siniflar
{
    public class Cari
    {
        [Key]
        public int Cariid { get; set; }
        [Column(TypeName = "Varchar"), StringLength(30, ErrorMessage = "En fazla 30 karakter girebilirsiniz.")]
        [Required(ErrorMessage ="Bu alan boş geçilemez.")]
        public string CariAd { get; set; }
        [Column(TypeName = "Varchar"), StringLength(30,ErrorMessage ="En fazla 30 karakter girebilirsiniz.")]
        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public string CariSoyad { get; set; }
        [Column(TypeName = "Varchar"), StringLength(13)]
        public string CariSehir { get; set; }
        [Column(TypeName = "Varchar"), StringLength(50),EmailAddress(ErrorMessage ="Lütfen geçerli bir email adresi girdiğinizden emin olunuz."),Required(AllowEmptyStrings =false,ErrorMessage = "Bu alan boş geçilemez.")]
        public string CariMail { get; set; }
        public bool Durum { get; set; }
        public ICollection<SatisHareket> SatisHareketler { get; set; }
    }
}