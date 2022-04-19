using System;

namespace WebApi.Models.Users
{
    public class YeniUyeRequest
    {
       
        
        public int Id { get; set; }
        public string Kayır_Tarihi { get; set; }
        public long? TC { get; set; }
        public string Doğum_Tarihi { get; set; }
        public string AD { get; set; }
        public string SOYAD { get; set; }

        public string AnaADI { get; set; }
        public string BabaADI { get; set; }
        public string TELEFONNO { get; set; }
        public string AdresIS { get; set; }

        public string Mail { get; set; }
        public int Cinsiyet { get; set; }
        public string AdresEV { get; set; }
        public int? MESLEK { get; set; }
        public int? PartiGOREVI { get; set; }

        public int? GorevYeriIL { get; set; }
        public int? GorevYeriILCE { get; set; }
        public string RESİM { get; set; }
        
    }
}