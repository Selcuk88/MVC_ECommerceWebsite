using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Web;

namespace MVC_ECommerceWebsite.Models.Siniflar
{
    public class Urun
    {
        [Key]
        public int Urunid { get; set; }
        [Column(TypeName ="Varchar"),StringLength(30)]
        public string UrunAd { get; set; }
        [Column(TypeName = "Varchar"), StringLength(30)]
        public string Marka { get; set; }
        public short Stok { get; set; }
        public decimal AlisFiyat { get; set; }
        public decimal SatisFiyat { get; set; }
        public bool Durum { get; set; }
        [Column(TypeName = "Varchar"), StringLength(250)]
        public string UrunGorsel { get; set; }
        [ForeignKey("Kategori")]             
        public int KategoriID { get; set; }
        public virtual Kategori Kategori { get; set; }
        public ICollection<SatisHareket> SatisHareketler { get; set; }

    }
}