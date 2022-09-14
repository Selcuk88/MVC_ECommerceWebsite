using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MVC_ECommerceWebsite.Models.Siniflar
{
    public class Context:DbContext
    {
        public DbSet<Admin> Adminler { get; set; }
        public DbSet<Cari> Cariler { get; set; }
        public DbSet<Departman> Departmanlar { get; set; }
        public DbSet<Fatura> Faturalar { get; set; }
        public DbSet<FaturaKalem> FaturaKalemler { get; set; }
        public DbSet<Gider> Giderler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Personel> Personeller { get; set; }
        public DbSet<SatisHareket> SatisHareketler { get; set; }
        public DbSet<Urun> Urunler { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}