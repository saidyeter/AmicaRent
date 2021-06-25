using System.Collections.Generic;

namespace AmicaRent.OfficialWeb.Models
{
    public class AracFiltreViewModel
    {
        public int alisLokasyon { get; set; }
        public int donusLokasyon { get; set; }
        //public string alisGun { get; set; }
        public string alisTarihGun { get; set; }
        public string alisTarihAy { get; set; }
        public string alisTarihYil { get; set; }
        public string alisSaat { get; set; }
        //public string donusGun { get; set; }
        public string donusTarihGun { get; set; }
        public string donusTarihAy { get; set; }
        public string donusTarihYil { get; set; }
        public string donusSaat { get; set; }
        public List<AmicaRent.OfficialWeb.Models.AracViewModel> aracList { get; set; }

    }
}