//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class viewCariEhliyet
    {
        public int CariEhliyet_ID { get; set; }
        public Nullable<int> Cari_ID { get; set; }
        public string Cari_AdSoyad { get; set; }
        public Nullable<System.DateTime> CariEhliyet_VerilisTarihi { get; set; }
        public Nullable<System.DateTime> CariEhliyet_GecerlilikTarihi { get; set; }
        public string CariEhliyet_DogumYeri { get; set; }
        public string CariEhliyet_EhliyetNumarasi { get; set; }
        public string EhliyetSinif_Adi { get; set; }
        public string KanGrubu_Adi { get; set; }
    }
}
