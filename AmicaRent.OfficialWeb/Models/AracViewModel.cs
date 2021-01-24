using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AmicaRent.OfficialWeb.Models
{
    public class AracViewModel
    {
        public int Arac_ID { get; set; }
        public string MarkaModel { get; set; }
        public double Fiyat { get; set; }
        public int Indirim { get; set; }
        public string Yil { get; set; }
        public int KM { get; set; }
        public string YakitTuru { get; set; }
        public string VitesTuru { get; set; }
        public string Base64Resim { get; set; }
    }
}