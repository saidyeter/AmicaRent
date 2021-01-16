using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace AmicaRent.DataAccess
{
    public class AmicaRentDBContext : DbContext
    {//string connectionString
        public AmicaRentDBContext(string connectionString)
            : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<System.Data.Entity.ModelConfiguration.Conventions.PluralizingTableNameConvention>();
        }

        public virtual DbSet<Arac> Arac { get; set; }
        public virtual DbSet<AracFile> AracFile { get; set; }
        public virtual DbSet<AracGrup> AracGrup { get; set; }
        public virtual DbSet<AracKasaTipi> AracKasaTipi { get; set; }
        public virtual DbSet<AracMarka> AracMarka { get; set; }
        public virtual DbSet<AracModel> AracModel { get; set; }
        public virtual DbSet<AracRenk> AracRenk { get; set; }
        public virtual DbSet<AracYakitTuru> AracYakitTuru { get; set; }
        public virtual DbSet<AracKredi> AracKredi { get; set; }
        public virtual DbSet<Banka> Banka { get; set; }
        public virtual DbSet<BankaBilgileri> BankaBilgileri { get; set; }
        public virtual DbSet<SysFile> SysFile { get; set; }
        public virtual DbSet<IslemFile> IslemFile { get; set; }
        public virtual DbSet<Cari> Cari { get; set; }
        public virtual DbSet<CariEhliyet> CariEhliyet { get; set; }
        public virtual DbSet<CariSehir> CariSehir { get; set; }
        public virtual DbSet<CariUyruk> CariUyruk { get; set; }
        public virtual DbSet<EhliyetSinif> EhliyetSinif { get; set; }
        public virtual DbSet<EkstraHizmetler> EkstraHizmetler { get; set; }
        public virtual DbSet<EkSurucu> EkSurucu { get; set; }
        public virtual DbSet<Islem> Islem { get; set; }
        public virtual DbSet<IslemEkstraHizmetler> IslemEkstraHizmetler { get; set; }
        public virtual DbSet<IslemTahsilat> IslemTahsilat { get; set; }
        public virtual DbSet<KanGrubu> KanGrubu { get; set; }
        public virtual DbSet<Kullanici> Kullanici { get; set; }
        public virtual DbSet<KullaniciRolIliskileri> KullaniciRolIliskileri { get; set; }
        public virtual DbSet<KullaniciRolTanimlari> KullaniciRolTanimlari { get; set; }
        public virtual DbSet<Lokasyon> Lokasyon { get; set; }
        public virtual DbSet<OdemeTipi> OdemeTipi { get; set; }
        public virtual DbSet<Servis> Servis { get; set; }
        public virtual DbSet<ServisFirma> ServisFirma { get; set; }
        public virtual DbSet<viewAracList> viewAracList { get; set; }
        public virtual DbSet<viewAracModel> viewAracModel { get; set; }
        public virtual DbSet<viewCari> viewCari { get; set; }
        public virtual DbSet<viewCariEhliyet> viewCariEhliyet { get; set; }
        public virtual DbSet<viewIslem> viewIslem { get; set; }
        public virtual DbSet<viewServis> viewServis { get; set; }
    }

}
