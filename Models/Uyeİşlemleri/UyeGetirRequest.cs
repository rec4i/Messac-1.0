using System;
using System.Collections.Generic;
using qrmenu.Entities;
using WebApi.Entities;

namespace qrmenu.Models.Uyeİşlemleri
{
    public class UyeGetirRequest
    {
        public DateTime Bas_Tar { get; set; }
        public DateTime Bit_Tar { get; set; }

        public List<City> Şehirler { get; set; }

        public List<Town> İlçeler { get; set; }

        public List<Cinsiyet> Cinsiyet { get; set; }

        public List<Parti_Görevi> Parti_Görevi { get; set; }

        public List<Meslekler> Meslek { get; set; }

        public string Doğum_Tar_Bas { get; set; }

        public string Doğum_Tar_Son { get; set; }


    }
}